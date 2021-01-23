    Task.Run(() =>
                {
    
                    int[] values = new int[12];
                    for (int n = 0; n < values.Length; n++)
                    {
                        values[n] = n;
                    }
    
                    // Eric Ouellet Algorithm
                    int count = 0;
                    var stopwatch = new Stopwatch();
                    stopwatch.Reset();
                    stopwatch.Start();
                    Permutations.ForAllPermutation(values, (vals) =>
                    {
                        foreach (var v in vals)
                        {
                            count++;
                        }
                        return false;
                    });
                    stopwatch.Stop();
                    Console.WriteLine($"This {count} items in {stopwatch.ElapsedMilliseconds} millisecs");
    
                    // Simple Plan Algorithm
                    count = 0;
                    stopwatch.Reset();
                    stopwatch.Start();
                    PermutationsSimpleVar permutations2 = new PermutationsSimpleVar();
                    permutations2.Permutate(1, values.Length, (int[] vals) =>
                    {
                        foreach (var v in vals)
                        {
                            count++;
                        }
                    });
                    stopwatch.Stop();
                    Console.WriteLine($"Simple Plan {count} items in {stopwatch.ElapsedMilliseconds} millisecs");
    
                    // ErezRobinson Algorithm
                    count = 0;
                    stopwatch.Reset();
                    stopwatch.Start();
                    foreach(var vals in PermutationsErezRobinson.QuickPerm(values))
                    {
                        foreach (var v in vals)
                        {
                            count++;
                        }
                    };
                    stopwatch.Stop();
                    Console.WriteLine($"Erez Robinson {count} items in {stopwatch.ElapsedMilliseconds} millisecs");
                });
