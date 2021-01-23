         static void ComputeParallelForWithTLS()
                {
                    var collection = new List<int>() { 1000, 2000, 3000, 4000 }; // values used as sleep parameter
                    var sync = new object();
                    TimeSpan averageTime = new TimeSpan();
                    int amountOfItemsDone = 0; // referenced by the TPL, increment it with lock / interlocked.increment
        
                    Parallel.For(0, collection.Count,
                        () => new TimeSpan(),
                        (i, loopState, tlData) =>
                        {
                            var sw = Stopwatch.StartNew();
                            DoWork(collection, i);
                            sw.Stop();
                            return sw.Elapsed;
                        },
                        threadLocalData =>   // Called each time a task finishes
                        {
                            lock (sync)
                            {
                                averageTime += threadLocalData; // add time used for this task to the total.
                            }
                            Interlocked.Increment(ref amountOfItemsDone); // increment the tasks done
                            Console.WriteLine(averageTime.TotalMilliseconds / amountOfItemsDone + ms."); 
    /*print out the average for all done tasks so far. For an estimation, 
    multiply with the remaining items.*/
                        });
                }
                static void DoWork(List<int> items, int current)
                {
                    System.Threading.Thread.Sleep(items[current]);
                }
