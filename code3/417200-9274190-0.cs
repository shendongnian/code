    class Program
    {
        private static WebServiceCaller.TCMDelegate _wscDelegate;
        private static readonly WebServiceCaller _wsCaller = new WebServiceCaller();
        static void Main(string[] args)
        {
            _wscDelegate = _wsCaller.TimeConsumingMethod;
            MakeWSCallAsync();
            Console.WriteLine("Enter Q to quit");
            while (Console.ReadLine().ToUpper().Trim()!="Q"){}
        }
        public static void MakeWSCallAsync()
        {
            _wscDelegate.BeginInvoke(OnWSCallComplete, null);
        }
        public static void OnWSCallComplete(IAsyncResult ar)
        {
            Console.WriteLine("Result {0}", _wscDelegate.EndInvoke(ar));
            MakeWSCallAsync();
        }
    }
    class WebServiceCaller
    {
        public delegate int TCMDelegate();
        public int TimeConsumingMethod()
        {
            try
            {
                // Simulates a method running for 1 minute
                Thread.Sleep(1000);
                return 1;
            }
            catch (ThreadAbortException e)
            {
                return -1;
            }
        }
    }
