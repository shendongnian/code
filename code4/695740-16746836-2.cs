    public class ApplicationPresenterWindowsDispatcher
    {
        private DateTime started;
        public Project Project { get; set; }
        /* Stuff necessary for this solution */
        private delegate void ComputationDelegate();
        private object Mutex = new object();
        private bool IsValid = true;
        private DateTime LastInvalidated;
        private Task ObservationTask;
        private Dispatcher MainThreadDispatcher;
        private CancellationTokenSource TokenSource;
        private CancellationToken Token;
        public void ObserveAndTriggerComputation(CancellationToken ctoken)
        {
            while (true)
            {
                ctoken.ThrowIfCancellationRequested();
                lock (Mutex)
                {
                    if (!IsValid && (DateTime.Now - LastInvalidated).TotalSeconds > 1)
                    {
                        IsValid = true;
                        ComputationDelegate compute = new ComputationDelegate(UpdateProject);
                        MainThreadDispatcher.BeginInvoke(compute);
                    }
                }
            }
        }
        public ApplicationPresenterWindowsDispatcher()
        {
            // Create the project and subscribe to the invalidation event
            Project = new Project();
            Project.Invalidated += Project_Invalidated;
            // Set up observation task
            MainThreadDispatcher = Dispatcher.CurrentDispatcher;
            Mutex = new object();
            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
            ObservationTask = Task.Factory.StartNew(() => ObserveAndTriggerComputation(Token), Token);
            // Simulate the user doing stuff
            started = DateTime.Now;
            Project.SimulateUserDoingStuff();
        }
        void Project_Invalidated()
        {
            lock (Mutex)
            {
                IsValid = false;
                LastInvalidated = DateTime.Now;
            }
        }
        void UpdateProject()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Running HeftyComputation() at {0}s", (DateTime.Now - started).TotalSeconds));
            Project.HeftyComputation();
        }
    }
