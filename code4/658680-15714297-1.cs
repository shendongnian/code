    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MinimalTaskDemo
    {
        class Program
        {
            private static readonly Queue<Task> WaitingTasks = new Queue<Task>();
            private static readonly Dictionary<int, Task> RunningTasks = new Dictionary<int, Task>();
            public static int MaxRunningTasks = 100; // vary this to dynamically throttle launching new tasks 
    
            static void Main(string[] args)
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                Worker.Done = new Worker.DoneDelegate(WorkerDone);
                for (int i = 0; i < 1000; i++)  // queue some tasks
                {
                    // task state (i) will be our key for RunningTasks
                    WaitingTasks.Enqueue(new Task(id => new Worker().DoWork((int)id, token), i, token));
                }
                LaunchTasks();
                Console.ReadKey();
                if (RunningTasks.Count > 0)
                {
                    lock (WaitingTasks) WaitingTasks.Clear();
                    tokenSource.Cancel();
                    Console.ReadKey();
                }
            }
    
            static async void LaunchTasks()
            {
                // keep checking until we're done
                while ((WaitingTasks.Count > 0) || (RunningTasks.Count > 0))
                {
                    // launch tasks when there's room
                    while ((WaitingTasks.Count > 0) && (RunningTasks.Count < MaxRunningTasks))
                    {
                        Task task = WaitingTasks.Dequeue();
                        lock (RunningTasks) RunningTasks.Add((int)task.AsyncState, task);
                        task.Start();
                    }
                    UpdateConsole();
                    await Task.Delay(300); // wait before checking again
                }
                UpdateConsole();    // all done
            }
    
            static void UpdateConsole()
            {
                Console.Write(string.Format("\rwaiting: {0,3:##0}  running: {1,3:##0} ", WaitingTasks.Count, RunningTasks.Count));
            }
    
            // callback from finished worker
            static void WorkerDone(int id)
            {
                lock (RunningTasks) RunningTasks.Remove(id);
            }
        }
    
        internal class Worker
        {
            public delegate void DoneDelegate(int taskId);
            public static DoneDelegate Done { private get; set; }
            private static readonly Random Rnd = new Random();
    
            public async void DoWork(object id, CancellationToken token)
            {
                for (int i = 0; i < Rnd.Next(20); i++)
                {
                    if (token.IsCancellationRequested) break;
                    await Task.Delay(100);  // simulate work
                }
                Done((int)id);
            }
        }
    }
