    public abstract class Module
    {
        public Module(Mpi mpi)
        {
            this.Mpi = mpi;
        }
        protected Mpi Mpi { get; private set; } // getter is visible to children, setter only for class itself
    }
