            var sortedInts = new[]
                                 {
                                     new[] {1, 3, 5, 7, 8},
                                     new[] {1, 2, 5, 6, 6},
                                     new[] {6, 9, 9, 10},
                                     new[] {2, 4, 5, 5, 9}
                                 };
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < 1000000; i++)
            {
                var merge = MergeSorted(sortedInts);
            }
            var ticks = sw.ElapsedTicks;
            for (var i = 0; i < 1000000; i++)
            {
                var merge2 = MergeSorted2(sortedInts);
            }
            var ticks2 = sw.ElapsedTicks - ticks;
            sw.Stop();
            // K-Way
            Console.WriteLine(ticks);  // 9,964,124
            // Prioritize
            Console.WriteLine(ticks2); // 20,920,307
