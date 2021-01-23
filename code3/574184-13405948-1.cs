        class Program
        {
        public static string[] addresses = {"http://microsoft.com", "http://yahoo.com", "http://google.com"};
        static void Main(string[] args)
        {
            List<Task<PingReply>> pingTasks = new List<Task<PingReply>>();
            foreach (var address in addresses)
            {
                pingTasks.Add(PingAsync(address));
            }
            //Wait for all the tasks to complete
            Task.WaitAll(pingTasks.ToArray());
            //Now you can iterate over your list of pingTasks
            foreach (var pingTask in pingTasks)
            {
                //pingTask.Result is whatever type T was declared in PingAsync
                Console.WriteLine(pingTask.Result);
            }
        }
        static Task<PingReply> PingAsync(string address)
        {
            var tcs = new TaskCompletionSource<PingReply>();
            Ping ping = new Ping();
            ping.PingCompleted += (obj, sender) =>
                {
                    tcs.SetResult(sender.Reply);
                };
            ping.SendAsync(address, new object());
            return tcs.Task;
        }
    }
