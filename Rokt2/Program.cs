using System;
using System.Collections.Generic;
using System.Linq;


namespace Rhino2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var couponsList = new List<List<int>>();
                couponsList.Add(new List<int>() { 1, 3, 46, 1, 3, 9, 47 });
                couponsList.Add(new List<int>() { 6, 6, 3, 9, 3, 5, 1, 12 });
                couponsList.Add(new List<int>() { 7, 6, 6, 3, 9, 3, 5, 1, 12, 0, 12 });
                couponsList.Add(new List<int>() { 7, 6, 6, 3, 4, 3, 5, 1, 12, 0, 8 });
                couponsList.Add(new List<int>() { 123456789, 987654321, 555555555, 666666666, 77777777, 100, 10000000, 320156321, 1111111110 });

                foreach (var list in couponsList)
                {
                    Console.WriteLine(NumberOfPayment(list));
                }

            } while (Console.ReadLine() != null);
        }

        // Complete the numberOfPayment function below.
        static int NumberOfPayment(List<int> rhinoCoupons)
        {
            //get the value to add up to
            var costOfLunch = rhinoCoupons[rhinoCoupons.Count - 1];

            //now remove the above value from the list
            rhinoCoupons.RemoveAt(rhinoCoupons.Count-1);

            //create a dictionary of pairs found
            var uniquePairs = new Dictionary<int, int>();

            //we need an index check so we don't add the same value to itself
            var indexOfRhinoCoupon = -1;
            
            foreach (var rhinoCoupon in rhinoCoupons)
            {
                indexOfRhinoCoupon++;
                var indexOfCoupon = -1;
                foreach (var coupon in rhinoCoupons)
                {
                    //make sure we don't add the value to itself
                    indexOfCoupon++;
                    if (indexOfCoupon == indexOfRhinoCoupon)
                    {
                        continue;
                    }

                    //if we have a unique pair, add it to the dictionary
                    if (rhinoCoupon + coupon == costOfLunch)
                    {
                        if ((!uniquePairs.ContainsKey(rhinoCoupon) || !uniquePairs.ContainsValue(coupon)) &&
                            (!uniquePairs.ContainsKey(coupon) || !uniquePairs.ContainsValue(rhinoCoupon)))
                        {
                            uniquePairs.Add(rhinoCoupon, coupon);
                        }
                    }
                }
            }

            //return the spoils
            return !uniquePairs.Any() ? 0 : uniquePairs.Count;
        }
    }
}
