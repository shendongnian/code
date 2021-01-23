    public class MyCommand : ICommand
    {
        Action<bool> _action;
        public MyCommand(Action<bool> action)
        {
            _action = action;
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event System.EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            _action((bool)parameter);
        }
    }
