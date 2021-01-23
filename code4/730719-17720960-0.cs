    public class PerformMainTask()
    {
        Task1();
        Task2();
    
        Task.WaitAll(Task.Factory.StartNew(() => PerformLongTask()), Task.Factory.StartNew(() => { Task3(); Task4(); }));
    }
