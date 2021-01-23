        using System;
        using System.Threading.Tasks;
        static void StartTasks(int instances)
        {
            var tasks = new Task[instances];
            for (int i = 0; i < instances; i++)
            {
                tasks[i] = new Task((object param) =>
                {
                    var t = (int)param;
                    Console.Write("({0})", t);
                }, i);
            }
            Parallel.ForEach<Task>(tasks, (t) => { t.Start(); }); 
            Task.WaitAll(tasks);
        }
