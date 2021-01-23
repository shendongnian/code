    public class MyModule : Module
    {
        public Module(Mpi mpi)
            : base(mpi)
        {
            mpi = null; // base class will receive it as it was! not null
        }
    }
