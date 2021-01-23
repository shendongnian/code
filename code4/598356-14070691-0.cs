      private static IList<string> mystringList = new List<string>();
    static void Main(string[] args)
    {
        new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        //Acquire the lock
                        lock (mystringList)
                        {
                            //Do something with the data
                            Thread.Sleep(100);
                            Console.WriteLine("Lock acquired");
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception: " +exception.Message);
                }
            }).Start();
        new Thread(() =>
            {
                //Suppose we do something
                Thread.Sleep(1000);
                //And by some how reset the list to null
                mystringList = null;
            }).Start();
        Console.ReadLine();
    }
