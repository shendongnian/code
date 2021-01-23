    public MyCommand : ICommand
    {
        private readonly ViewModelA _a, ViewModelB _b;
        public MyCommand(ViewModelA a, ViewModelB b)
        {
            _a = a;
            _b = b;
        }
        public bool CanExecute(object arg)
        {
            // can-execute logic here
        }
        public void Execute(object arg)
        {
            _b.StateDataRequestedCommand.Execute("");
            _a.ProcessInfoRequestedCommand.Execute("");
        }
    }
