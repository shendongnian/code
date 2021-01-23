    public class ApplicationPresenterBasic
    {
        private DateTime started;
        public Project Project { get; set; }
        public ApplicationPresenterBasic()
        {
            // Create the project and subscribe to the invalidation event
            Project = new Project();
            Project.Invalidated += Project_Invalidated;
            // Simulate the user doing stuff
            started = DateTime.Now;
            Project.SimulateUserDoingStuff();
        }
        void Project_Invalidated()
        {
            UpdateProject();
        }
        void UpdateProject()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Running HeftyComputation() at {0}s", (DateTime.Now - started).TotalSeconds));
            Project.HeftyComputation();
        }
    }
