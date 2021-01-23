    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Run(() => FetchData(1));
            var t2 = Task.Run(() => FetchData(2));
            var t3 = Task.Run(() => FetchData(3));
            
            var index = Task.WaitAny(t1, t2, t3);
            Console.WriteLine("Task {0} finished first", index + 1);
            Task.WaitAll(t1, t2, t3);
            Console.WriteLine("All tasks have finished");
            Console.WriteLine("Press any key");
            Console.ReadKey(true);
        }
        static void FetchData(int clientNumber)
        {
            var client = new WebClient();
            string data = client.DownloadString("http://localhost:61852/api/values");
            Console.WriteLine("Client {0} got data: {1}", clientNumber, data);
        }
    }
