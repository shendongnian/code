            if (testThread.IsAlive)
            {
                testThread.Abort();
                bool blnFinishedAfterAbort = testThread.Join(TimeSpan.FromMilliseconds(1000));
                if (!blnFinishedAfterAbort)
                {
                    Console.WriteLine("Thread abort failed.");
                }
            }
            Console.WriteLine("main thread after abort call " + DateTime.Now.ToShortTimeString());
