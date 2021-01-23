    class Test
    {
        void Main()
        {
    	long start1;	
    	long start2;
    	QueryPerfCounter.QueryPerformanceCounter(out start1);
    	QueryPerfCounter.QueryPerformanceCounter(out start2);
    
    	System.Console.WriteLine(start1);
    	System.Console.WriteLine(start2);
        }
    
        [System.Runtime.InteropServices.DllImport("KERNEL32")]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
    }
