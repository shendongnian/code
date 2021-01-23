    class Program
    {
        private const int MaxThreads = 100; //way to high for this example.
        public static readonly BlockingCollection<User> users = new BlockingCollection<User>();
        static void Main(string[] args)
        {
            var cde = new CowndownEvent(MaxThreads);
            Run(); 
            for (int i = 0; i < 100000; i++)
            {
                var u = new User {Id = i, Name = "user " + i};
                users.Add(u);
            }
            users.CompleteAdding();
            cde.Wait();
        }
        static void Run()
        {
            for (int i = 0; i < MaxThreads; i++)
            {
                Task.Factory.StartNew(Process, TaskCreationOptions.LongRunning);
            }
        }
        static void Process()
        {
            foreach (var user in users.GetConsumingEnumerable())
            {
                Console.WriteLine(user.Id);
            }
            cde.Signal();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
