    public class Client : IThreadCompletedNotifier
    {
        private readonly Library library;
    
        public event Action ThreadCompleted;
    
        public Client(Library library)
        {
            this.library = library;
        }
    
        public void DoWorkInAThread()
        {
            var thread = new Thread(() =>
            {
                library.StartSomething();
                Thread.Sleep(10);
                Console.WriteLine("Client thread says: I'm done");
                if(ThreadCompleted != null)
                {
                   ThreadCompleted();
                }
            });
            thread.Start();
        }
    }
