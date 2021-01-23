    BackgroundWorker worker = .....;
      public static void Main(string[] args)
        {
            InitWorker();
            Console.Read();
        }
    public static void InitWorker()
    {
        ....
        worker.RunWorkerAsync();
    }
    
    
    static void worker_DoWork(....)
    {
      .....this is where I wrote the code...
    }
