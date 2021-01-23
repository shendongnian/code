        private static void connectUser(string username, string password, string server)
        {
            while (true)
            {
                Console.WriteLine("Connecting... " + username);
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            var server = "a.com";
            var alts = new string[] { "abc:abc", "bcd:bcd" };
            var tasks = new Task[alts.Length];
            for (int i = 0; i < alts.Length; i++)
            {
                String password = alts[i].Substring(alts[i].IndexOf(":") + 1);
                String username = alts[i].Substring(0, alts[i].IndexOf(":"));
                Console.WriteLine("Loaded account: " + username);
                tasks[i] = Task.Factory.StartNew(() => connectUser(username, password, server));
            }
            Task.WaitAll(tasks);
        }
