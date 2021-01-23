    static class Program
    {
        static void Main()
        {
            const int max = 3000000;
            var range = Enumerable.Range(0, max).ToArray();
            {
                var sw = new Stopwatch();
                sw.Start();
                Parallel.ForEach(range, i => { });
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
            {
                var tasks = new Task[max];
                var sw = new Stopwatch();
                sw.Start();
                foreach (var i in range)
                {
                    tasks[i] = new Task(()=> { });
                    //tasks[i].Start();
                }
                //Task.WaitAll(tasks);
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }
    }
