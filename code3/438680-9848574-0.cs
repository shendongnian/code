    public void DoFor(Action action, int numMilliseconds)
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).TotalMilliseconds < numMilliseconds)
            {
                // Not sure - is this relevant on another thread?
                Application.DoEvents();
                // Not sure if this is relevant either since you're on another thread
                Thread.Sleep(1);
                // Do your action
                action();
            }
        }
