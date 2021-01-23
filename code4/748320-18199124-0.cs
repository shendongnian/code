    public class MyViewModel
    {
        private MyCustomCommandFactory _commandFactory;
        private void _somethingToExecute;
        public MyViewModel(MyCustomCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }
        public ICommand ApplyChangesCommand  
        { 
            get 
            { 
                return _commandFactory.Create(_somethingToExecute, e=>true);
            }
        }
    }
