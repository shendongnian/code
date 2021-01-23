    public abstract class Module
    {
        protected Module()
        {
            this.Mpi = new Mpi();
        }
        protected Mpi Mpi { get; private set; } // getter is visible to children, setter only for class itself
    }
