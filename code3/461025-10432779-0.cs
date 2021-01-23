    public interface IThreadCompletedNotifier
    {
       event Action ThreadCompleted;
    }
    
    public class Library
    {
        public void StartSomething(IThreadCompletedNotifier notifier)
        {
            Console.WriteLine("Library says: StartSomething called");
            notifier.ThreadCompleted += () => Console.WriteLine("Libaray says: Client thread existed");
            var clientThread = Thread.CurrentThread;
            exitMonitorThread.Start();
        }
    }
