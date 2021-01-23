    public delegate void ExceptionHandler(Exception ex);
    public class Worker : BackgroundWorker
    {
        ExceptionHandler Handler { get; set; }
        public Worker(ExceptionHandler handler)
        {
            Handler = handler;
        }
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            for (var i = 0; i < (int)e.Argument; i++)
            {
                if (i%2 != 0) continue;
                try
                {
                    throw new ArgumentException(String.Format("{0}:{1}", i, "TEST EXCEPTION"));
                }
                catch (Exception ex)
                {
                    if (this.Handler != null)
                        Handler.Invoke(ex);
                }
            }
        }
    }
    class Program
    {
        public static void HandleException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        static event ExceptionHandler Handler;
        static void Main(string[] args)
        {
            Handler = new ExceptionHandler(HandleException);
            var worker = new Worker(Handler);
            worker.RunWorkerAsync(100);
            Console.ReadLine();
        }
    }
