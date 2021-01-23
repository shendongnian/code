        volatile int threadCount = 0;
        private void GetPredicateAsync(string text, Action<object> DoneCallback)
        {
            
            threadCount++;
            ThreadPool.QueueUserWorkItem((x) =>
            {                
                lock (_lock)
                {
                    if (threadCount > 1) // disable executing threads at same time
                    {
                        threadCount--;
                        return; // if a new thread is created exit. 
                                // let the newer task do work!
                    }
                    // do work in here
                    
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        threadCount--;                        
                        DoneCallback(Foo);
                    }));
                                       
                }
            },text);
        }
