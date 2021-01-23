    public interface IWorker
    {
        Task DoWorkAsync(string data);
        void DoWork(string data);
    }
    public class Worker : IWorker
    {
        public Task DoWorkAsync(string data)
        {
            return Task.Run(() => DoWork(data));
        }
        public void DoWork(string data)
        {
            Console.WriteLine(data);
            Thread.Sleep(100);
        }
    }
    public class Runner
    {
        public void Callback()
        {
            Console.WriteLine("Everything done");
        }
        public void Run()
        {
            var workers = new List<IWorker> {new Worker(), new Worker(), new Worker()};
            var tasks = workers.Select(t => t.DoWorkAsync("some data"));
            
            Task.WhenAll(tasks).ContinueWith(task => Callback());
            Console.WriteLine("Waiting");
        }
    }
