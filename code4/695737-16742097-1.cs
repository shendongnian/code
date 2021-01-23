    public class ApplicationPresenterRX
    {
        private DateTime started;
        public Project Project { get; set; }
    
        public ApplicationPresenterRX()
        {
            // Create the project and subscribe to the invalidation event
            Project = new Project();
    
            // Convert events into observable stream of events based on custom event.
            Observable.FromEvent(ev => { this.Project.Invalidated += () => ev(); },
                             ev => { this.Project.Invalidated -= () => ev();})
                // Only propagate a maximum of 1 event per second (dropping others) 
                .Throttle(TimeSpan.FromSeconds(1))
                // Finally execute the task needed asynchronously
                // The only caveat is that if the code in Project.HeftyComputation updates UI components in WPF you may need to marshal the UI updates onto the correct thread to make it work.
                .Subscribe(e => { Task.Run(Project.HeftyComputation); });
            
            // Simulate the user doing stuff
            started = DateTime.Now;
            Project.SimulateUserDoingStuff();
        }
    }
