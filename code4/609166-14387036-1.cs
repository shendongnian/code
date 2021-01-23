    public class RelayCommand<T> : ICommand
    {
        private Action<T> _execute;
        private Predicate<T> _canexecute;
        public RelayCommand(Action<T> execute, Predicate<T> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canexecute == null) return false;
            else return _canexecute((T)parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
