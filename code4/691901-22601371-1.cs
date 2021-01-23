    class TestAsyncAwait
    {
        public void GetEntities()
        {
            for (int i = 0; i < 4; i++)
            {
                var a = getEntities(i);
                saveEntitiesAsync(a);
            }
            Console.WriteLine("\nPress any key to close\n");
            Console.ReadKey();
        }
        private List<string> getEntities(int i)
        {
            Console.Write("getting Entities for id={0}...", i);
            Thread.Sleep(2000);
            var r = new List<string> { i.ToString(), " Hello!" };
            Console.WriteLine("done, has the Entities for id={0}\n", i);
            return r;
        }
        async void saveEntitiesAsync(List<string> a)
        {
            var sb = new StringBuilder();
            await Task.Run(() =>
            {
                Thread.Sleep(4000); // simulates long task
                foreach (string s in a) sb.Append(s);
            });
            // shows the thread in action
            Trace.WriteLine("saved: " + sb.ToString());
        }
    }
