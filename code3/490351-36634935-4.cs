       Task.Run(() =>
        {
            int[] values = new int[12];
            for (int n = 0; n < values.Length; n++)
            {
                values[n] = n;
            }
            int count = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();
            Permutations.ForAllPermutation(values, (vals) =>
            {
                foreach (var v in vals)
                {
                    count++;
                }
                return false;
            });
            stopWatch.Stop();
            Console.WriteLine($"This {count} items in {stopWatch.ElapsedMilliseconds} millisecs");
            count = 0;
            stopWatch.Reset();
            stopWatch.Start();
            Permutations2 permutations2 = new Permutations2();
            permutations2.Permutate(1, values.Length, (int[] vals) =>
            {
                foreach (var v in vals)
                {
                    count++;
                }
            });
            stopWatch.Stop();
            Console.WriteLine($"Simple Plan {count} items in {stopWatch.ElapsedMilliseconds} millisecs");
            count = 0;
            stopWatch.Reset();
            stopWatch.Start();
            foreach(var vals in Permutation3.QuickPerm(values))
            {
                foreach (var v in vals)
                {
                    count++;
                }
            };
            stopWatch.Stop();
            Console.WriteLine($"Erez Robinson {count} items in {stopWatch.ElapsedMilliseconds} millisecs");
        });
    }
