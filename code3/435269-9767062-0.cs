    private static void Main()
    {
       List<Task> tasks = new List<Task>();
       for (int i = 0; i < 100; i++)
       {
           if (i % 10 == 0)
           {
               Console.WriteLine("Waiting for all tasks to complete");
               Task.WaitAll(tasks.ToArray());
               Console.WriteLine("All tasks have completed. Continuing...");
               tasks.Clear();
           }
           Task task = new Task(SubTask, new TaskState(i));
           task.Start();
           tasks.Add(task);
       }
    }
    public class TaskState
    {
        public TaskState(int id)
        {
            TaskId = id;
        }
        public int TaskId { get; set; }
    }
    private static void SubTask(object state)
    {
        TaskState taskState = (TaskState) state;
        Thread.Sleep(1000);
        Console.WriteLine("Task " +  taskState.TaskId + " completed");
    }
