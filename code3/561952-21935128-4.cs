    Parallel.ForEach(testList, item =>
                {
                    
                    var priviousePrio = Thread.CurrentThread.Priority;
                    // Set your desired priority
                    Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                    TestCalc(item);
                    
                    //Reset priviouse priority of the TPL Thread
                    Thread.CurrentThread.Priority = priviousePrio;
                });
