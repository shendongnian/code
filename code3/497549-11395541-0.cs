        System.Threading.AutoResetEvent are = new System.Threading.AutoResetEvent(false);
        double d = 0;
        public void ThreadA(object state)
        {
            while (true)
            {
                d++;
                are.Set();
            }
        }
        public void ThreadB(object state)
        {
            while (true)
            {
                are.WaitOne();
                double current = d;
            }
        }
