    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class User
        {
            public string Name;
        }
        class Program
        {
            readonly BlockingCollection<User> _queue = new BlockingCollection<User>();
            void run()
            {
                var background = Task.Factory.StartNew(process); // Start the processing threads.
                // Make up 50 sample users.
                var users = Enumerable.Range(0, 50).Select(n => new User{Name = n.ToString()});
                foreach (var user in users) // Add some sample data.
                    _queue.Add(user);
                Console.WriteLine("Press <RETURN> to exit.");
                Console.ReadLine();
                _queue.CompleteAdding();
                background.Wait();
                Console.WriteLine("Exited.");
            }
            void process() // Process the input queue,
            {
                int taskCount = 4;  // Let's use 4 threads.
                var actions = Enumerable.Repeat<Action>(processQueue, taskCount);
                Parallel.Invoke(actions.ToArray());
            }
            void processQueue()
            {
                foreach (User user in _queue.GetConsumingEnumerable())
                    processUser(user);
            }
            void processUser(User user)
            {
                Console.WriteLine("Processing user " + user.Name);
                Thread.Sleep(200); // Simulate work.
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
