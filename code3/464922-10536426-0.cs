    public interface ICommand
    {
        void Execute();
    }
    //Concrete implementation:
    public TestCommand : ICommand
    {
        public void Execute()
        {
            //Do something
        }
    }
