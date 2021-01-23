            Task<int> task1 = Task<int>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return 10;
            });
            Task<int> task2 = Task<int>.Factory.StartNew(() => 15);
            Task<int>[] tasks = {task1, task2};
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Task.WaitAll(tasks);
                sw.Stop();
                Console.WriteLine(String.Format("tasks completed in {0}ms", sw.ElapsedMilliseconds));
            }
            catch
            {
                Console.WriteLine("Error");
            }
            Console.ReadLine();
