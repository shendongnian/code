        private class CustomTimer : IDisposable
        {
            private int duration = 1000;
            private Action<object> tick;
            private object obj;
            private Thread thread;
            private bool start = false;
            public CustomTimer(int duration, Action<object> tick)
            {
                this.duration = duration;
                this.tick = tick;
            }
            public void Start(object obj)
            {
                this.obj = obj;
                start = true;
                if (thread == null)
                {
                    keepRunning = true;
                    thread = new Thread(ThreadMethod);
                    thread.Start();
                }
                else
                {
                    if (thread.ThreadState == ThreadState.WaitSleepJoin)
                        thread.Interrupt();
                }
            }
            public void Stop()
            {
                if (!start)
                    return;
                start = false;
                if (thread.ThreadState == ThreadState.WaitSleepJoin)
                    thread.Interrupt();
            }
            public bool IsStopped
            {
                get { return !start; }
            }
            private bool keepRunning = false;
            private void ThreadMethod()
            {
                while (keepRunning)
                {
                    if (start)
                    {
                        try { Thread.Sleep(duration); } catch { }
                        if (start && keepRunning)
                            tick(this.obj);
                    }
                    else if(keepRunning)
                    {
                        try { Thread.Sleep(int.MaxValue); } catch { }
                    }
                }
            }
            public void Dispose()
            {
                this.keepRunning = false;
                this.start = false;
                if (thread.ThreadState == ThreadState.WaitSleepJoin)
                    thread.Interrupt();
                if (thread.ThreadState == ThreadState.WaitSleepJoin)
                    thread.Interrupt();
            }
        }
