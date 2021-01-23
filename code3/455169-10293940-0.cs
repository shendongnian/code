    public class RelayCommand : ICommand, IDisposable
    {
        #region Fields
        List<EventHandler> _canExecuteSubscribers = new List<EventHandler>();
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields
        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors
        #region ICommand
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                _canExecuteSubscribers.Add(value);
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                _canExecuteSubscribers.Remove(value);
            }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion // ICommand
        #region IDisposable
        public void Dispose()
        {
            _canExecuteSubscribers.ForEach(h => CanExecuteChanged -= h);
            _canExecuteSubscribers.Clear();
        }
        #endregion // IDisposable
    }
