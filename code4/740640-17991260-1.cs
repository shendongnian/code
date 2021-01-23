    public static void doWork(IEnumerable<string> _source)
        {
            var _tokenSource = new CancellationTokenSource();
            var fileTasks = from file in _source select 
                            Task.Factory.StartNew(() =>
                                      {
                                          Console.WriteLine("Processing " + file );
                                          //do file operation
                                          Thread.Sleep(5000);
                                          Console.WriteLine("Finished Processing " + file);
                                      },
                                  _tokenSource.Token);
            Console.WriteLine("Waiting for tasks");
            Task.WaitAll(fileTasks.ToArray(), _tokenSource.Token);
            Console.WriteLine("All tasks finished");            
        }
        static void Main(string[] args)
        {
            var fileList = new List<string> {"file1", "file2", "file3"};
            doWork(fileList);
            Console.ReadLine();
        }
