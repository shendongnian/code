    class Work
    {
            int _delay;
            private Work(int delay) { _delay = delay; }
            public void Execute() { Thread.Sleep(_delay); }
            public static IEnumerable<Work> GetAllTasks()
            {
                Random r = new Random(4711);
                for (int i = 0; i < 10; i++)
                    yield return new Work(r.Next(100, 5000));
            }
     }
    
    static class TaskExecuter
    {
            public static void Execute()
            {
                foreach (Work task in Work.GetAllTasks())
                {
                     task.Execute();
                }
            }
       }
    void Main()
    {
    	System.Threading.Tasks.Parallel.ForEach(Work.GetAllTasks(), new Action<Work>(task =>
    {
       //Execute();
    }));
    }
