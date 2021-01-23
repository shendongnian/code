    public abstract class Module
    {
        public abstract Mpi Mpi { get; set; } // to inherit you must implement getter (you don't need it) and setter (what you're asking about)
    
        public abstract void Main(); // to inherit you must implement too
    }
