        static object numWaiting = 0;
        static object single = new object();
        ResultType DoSomething(string[] argList, bool highPriority = false)
        {
            try
            {
                if (highPriority)
                {
                    lock (numWaiting) { numWaiting = (int)numWaiting + 1; }
                }
                for (;;)
                {
                    lock (single)
                    {
                        if (highPriority || (int)numWaiting == 0)
                        {
                            return DoSomethingSingle(argList);
                        }
                    }
                    // Sleep gives other threads a chance to enter the lock
                    Thread.Sleep(0);
                }
            }
            finally
            {
                if (highPriority)
                {
                    lock (numWaiting) { numWaiting = (int)numWaiting - 1; }
                }
            }
        }
