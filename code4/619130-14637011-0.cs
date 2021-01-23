    class Program
    {
        static void Main(string[] args)
        {
            new Action(() => Worker()).BeginInvoke(null,null);
            Thread.Sleep(1000);
            Console.WriteLine("Main ends here");
        }
        static void Worker()
        {
            Thread.CurrentThread.IsBackground = false;
            Console.WriteLine("Worker started. Bg {0} Tp {1}.", 
                Thread.CurrentThread.IsBackground, 
                Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(5000);
            Console.WriteLine("Worker ends here");
       
