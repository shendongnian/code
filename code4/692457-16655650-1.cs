    public abstract class CommandBase : ICommand
    {
        public abstract bool CanExecute(object o);
        public abstract void Execute(object o);
    
        public PropertyChangedBase ViewModel { get; set; }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    
