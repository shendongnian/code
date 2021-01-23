    public class MyTask { ... }
    
    private BlockingCollection<MyTask> _tasks = new BlockingCollection<MyTask>();
    
    private void AddTask(MyTask task)
    {
      _tasks.Add(task);
    }
    
    private void StartConsumer()
    {
       // I have used a task API but you can very well launch a new thread instead of task
       Task.Factory.StartNew(() =>
         {
            while (!_tasks.IsCompleted)
            {
                var task = _tasks.Take();
                ProcessTask(task);
            }
         });
    }
