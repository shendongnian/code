    public abstract class Vehicle
    {
        public void Run()
        {
            // Code that always runs before...
            RunCore();
            // Code that always runs after...
        }
        protected virtual void RunCore()
        {
        }
    }
