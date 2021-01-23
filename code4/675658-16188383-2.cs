      public class Command : ICommand
      {
        //private readonly Action<object> _execute;
        private readonly Action _execute;
    
        //private readonly Func<object, bool> _canExecute;
        private readonly Func<bool> _canExecute;//instead of prev line 
        
        //public Command(Action<object> execute) 
        public Command(Action execute)//instead of prev line
          : this(execute, null)
        { }
        //public Command(Action<object> execute,
        public Command(Action execute,//instead of prev line 
        Func<bool> canExecute)//added instead of next line 
        //Func<object, bool> canExecute)
        {
          _execute = execute;
          _canExecute = canExecute;
        }
        public void Execute(object parameter)
        {
          //_execute(parameter);
          _execute();//added instead of prev line 
        }
        public bool CanExecute(object parameter)
        {
          return (_canExecute == null)
          //|| _canExecute(parameter);
          || _canExecute();//added instead of prev line 
        }
        public event EventHandler CanExecuteChanged
             = delegate { };
        public void RaiseCanExecuteChanged()
        {
          CanExecuteChanged(this, new EventArgs());
        }
      }
