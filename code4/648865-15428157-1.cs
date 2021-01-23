    using System;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                //int[] numbers = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
                //int[] numbers = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };
                int[] numbers = new[] {9, 1, 4, 15, -5, -41, -8, 78, 145, 14};
                var result = FindMaximumSubarray(numbers);
                Console.WriteLine("Range = {0}..{1}, Value = {2}", result.StartIndex, result.EndIndex, result.Value);
            }
            public static MaximumSubarray FindMaximumSubarray(int[] numbers)
            {
                int maxSoFar = numbers[0];
                int maxEndingHere = numbers[0];
                int begin = 0;
                int startIndex = 0;
                int endIndex = 0;
                for (int i = 1; i < numbers.Length; ++i)
                {
                    if (maxEndingHere < 0)
                    {
                        maxEndingHere = numbers[i];
                        begin = i;
                    }
                    else
                    {
                        maxEndingHere += numbers[i];
                    }
                    if (maxEndingHere > maxSoFar)
                    {
                        startIndex = begin;
                        endIndex = i;
                        maxSoFar = maxEndingHere;
                    }
                }
                return new MaximumSubarray
                {
                    StartIndex = startIndex,
                    EndIndex = endIndex,
                    Value = maxSoFar
                };
            }
            public struct MaximumSubarray
            {
                public int StartIndex;
                public int EndIndex;
                public int Value;
            }
        }
    }
                        
