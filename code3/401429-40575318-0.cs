            public class BlockingTaskQueue
            {
                private BlockingCollection<int> threadManager { get; set; } = null;
                public bool IsWorking
                {
                    get
                    {
                        return threadManager.Count > 0 ? true : false;
                    }
                }
                public BlockingTaskQueue(int maxThread)
                {
                    threadManager = new BlockingCollection<int>(maxThread);
                }
                public async Task AddTask(Task task)
                {
                    Task.Run(() =>
                    {
                        Run(task);
                    });
                }
                private bool Run(Task task)
                {
                    try
                    {
                        threadManager.Add(1);
                        task.Start();
                        task.Wait();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        threadManager.Take();
                    }
                }
            }
