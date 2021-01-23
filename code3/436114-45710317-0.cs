    I don't remember from where I copied it, but this code works well for me:
    
            public class QueryPerfCounter
        {
            [DllImport("KERNEL32")]
            private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        private long start;
        private long stop;
        private long frequency;
        double multiplier = 1.0e6;  // usecs / sec
    
        public QueryPerfCounter()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
        }
    
        public void Start()
        {
            QueryPerformanceCounter(out start);
        }
    
        public void Stop()
        {
            QueryPerformanceCounter(out stop);
        }
    
        public double Duration(int iterations)
        {
            return ((((stop - start) * multiplier) / frequency) / iterations);
        }
    }
