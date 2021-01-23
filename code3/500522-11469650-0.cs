        const int maxAllowedOrderLines = 15;
        const int minAllowedOrderLines = 10;
        static List<int> optimalOrderDisp = new List<int>();
        static void Main(string[] args)
        {
            int Lines = Convert.ToInt32(Console.ReadLine());
            int MinNumberOfBuckets = (int) Math.Ceiling((double) Lines / minAllowedOrderLines);
            int RemainingLines = Lines;
            int BucketLines = Lines / MinNumberOfBuckets;
            // Distribute evenly
            for (int i = 0; i < MinNumberOfBuckets; i++)
            {
                optimalOrderDisp.Add(i != MinNumberOfBuckets - 1 ? BucketLines : RemainingLines);
                RemainingLines -= BucketLines;
            }
            // Try to remove first bucket
            while (RemoveBucket())
            {
            }
            // Re-balance
            Lines = optimalOrderDisp.Sum();
            RemainingLines = Lines;
            BucketLines = (int) Math.Round((double) Lines / (optimalOrderDisp.Count));
            for (int i = 0; i < optimalOrderDisp.Count; i++)
            {
                optimalOrderDisp[i] = (i != optimalOrderDisp.Count - 1 ? BucketLines : RemainingLines);
                RemainingLines -= BucketLines;
            }
            // Re-balance to comply to min size
            for (int i = 0; i < optimalOrderDisp.Count - 1; i++)
                if (optimalOrderDisp[i] < minAllowedOrderLines)
                {
                    int delta = minAllowedOrderLines - optimalOrderDisp[i];
                    optimalOrderDisp[i] += delta;
                    optimalOrderDisp[optimalOrderDisp.Count - 1] -= delta;
                }
            Console.WriteLine(String.Join("\n", optimalOrderDisp.ToArray()));
        }
        static bool RemoveBucket()
        {
            if (optimalOrderDisp.Sum() > maxAllowedOrderLines * (optimalOrderDisp.Count - 1))
                return false;
            int Lines = optimalOrderDisp[0];
            int RemainingLines = Lines;
            int BucketLines = Lines / (optimalOrderDisp.Count - 1);
            // Remove bucket and re-distribute content evenly
            // Distribute evenly
            for (int i = 1; i < optimalOrderDisp.Count; i++)
            {
                optimalOrderDisp[i] += (i != optimalOrderDisp.Count - 1 ? BucketLines : RemainingLines);
                RemainingLines -= BucketLines;
            }
            optimalOrderDisp.RemoveAt(0);
            return true;
        }
