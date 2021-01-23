    List<ManualResetEvent> resetEvents = new List<ManualResetEvent>();
    .
    .
    .
    
    
     foreach(item in lisItem)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(aaa));
                    ManualResetEvent resetEvent = new ManualResetEvent(false);
                    resetEvents.Add(resetEvent);
                    thread.Start(resetEvent);
    
                }
                Console.WriteLine();
                WaitHandle.WaitAll(resetEvents.ToArray<WaitHandle>());
                Console.WriteLine("Finised executing all threads");
    
                
            }
        
    }
    .
    .
    .
        void aaa(object data)
        {
            ManualResetEvent resetEvent = data as ManualResetEvent;
            // completed execution
            Console.WriteLine(".");
            resetEvent.Set();
        }
