    public class ApplicationPresenterRX
    {
        private DateTime started;
        public Project Project { get; set; }
        public ApplicationPresenterRX()
        {
            // Create the project and subscribe to the invalidation event
            Project = new Project();
            var invalidations = Observable.FromEvent(ev => { this.Project.Invalidated += () => ev(); },
                                                     ev => { this.Project.Invalidated -= () => ev(); });
            var throttledInvalidations = invalidations.Throttle(TimeSpan.FromSeconds(1));
            throttledInvalidations.Subscribe(e => { UpdateProject(); });
            // Simulate the user doing stuff
            started = DateTime.Now;
            Project.SimulateUserDoingStuff();
        }
        void UpdateProject()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Running HeftyComputation() at {0}s", (DateTime.Now - started).TotalSeconds));
            Project.HeftyComputation();
        }
    }
