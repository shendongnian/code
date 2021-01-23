        private static async Task RunAgodaList(int threadNum, List<string> ids, EventWaitHandle waitHandle)
        {
            Console.WriteLine($"Start thread {threadNum}");
            foreach (var id in ids)
            {
                // start waiting
                waitHandle.WaitOne();
                File.AppendAllText(@".\Result.txt", text + Environment.NewLine);
                waitHandle.Set();
                // until release
                // ninja code
            }
            Console.WriteLine($"End thread {threadNum}");
        }
