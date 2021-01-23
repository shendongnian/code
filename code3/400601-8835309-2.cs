    using System; // Output is below
    using System.Linq;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var inputArray = Enumerable.Range(0, 10).ToArray();
                var grouped =
                    from Buckets in Enumerable.Range(1, inputArray.Length)
                    from IndexInBucket in Enumerable.Range(0, inputArray.Length / Buckets)
                    let StartPosInOriginalArray = IndexInBucket * Buckets
                    select new
                    {
                        BucketSize = Buckets,
                        BucketIndex = StartPosInOriginalArray,
                        Sum = inputArray.Skip(StartPosInOriginalArray).Take(Buckets).Sum()
                    };
                foreach (var group in grouped)
                {
                    Debug.Print(group.ToString());
                }
                Console.ReadKey();
            }
        }
    } // SCROLL FOR OUTPUT
    { BucketSize = 1, BucketIndex = 0, Sum = 1 }
    { BucketSize = 1, BucketIndex = 1, Sum = 2 }
    { BucketSize = 1, BucketIndex = 2, Sum = 3 }
    { BucketSize = 1, BucketIndex = 3, Sum = 4 }
    { BucketSize = 1, BucketIndex = 4, Sum = 5 }
    { BucketSize = 1, BucketIndex = 5, Sum = 6 }
    { BucketSize = 1, BucketIndex = 6, Sum = 7 }
    { BucketSize = 1, BucketIndex = 7, Sum = 8 }
    { BucketSize = 1, BucketIndex = 8, Sum = 9 }
    { BucketSize = 1, BucketIndex = 9, Sum = 10 }
    { BucketSize = 2, BucketIndex = 0, Sum = 3 }
    { BucketSize = 2, BucketIndex = 2, Sum = 7 }
    { BucketSize = 2, BucketIndex = 4, Sum = 11 }
    { BucketSize = 2, BucketIndex = 6, Sum = 15 }
    { BucketSize = 2, BucketIndex = 8, Sum = 19 }
    { BucketSize = 3, BucketIndex = 0, Sum = 6 }
    { BucketSize = 3, BucketIndex = 3, Sum = 15 }
    { BucketSize = 3, BucketIndex = 6, Sum = 24 }
    { BucketSize = 4, BucketIndex = 0, Sum = 10 }
    { BucketSize = 4, BucketIndex = 4, Sum = 26 }
    { BucketSize = 5, BucketIndex = 0, Sum = 15 }
    { BucketSize = 5, BucketIndex = 5, Sum = 40 }
    { BucketSize = 6, BucketIndex = 0, Sum = 21 }
    { BucketSize = 7, BucketIndex = 0, Sum = 28 }
    { BucketSize = 8, BucketIndex = 0, Sum = 36 }
    { BucketSize = 9, BucketIndex = 0, Sum = 45 }
    { BucketSize = 10, BucketIndex = 0, Sum = 55 }
