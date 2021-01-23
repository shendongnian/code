    public class DelegateCommand : ICommand
    {
        Action<object> m_executeDelegate;
        public DelegateCommand(Action<object> executeDelegate)
        {
            m_executeDelegate = executeDelegate;
        }
 
        public void Execute(object parameter)
        {
            m_executeDelegate(parameter);
        }
 
        public bool CanExecute(object parameter) { return true; }
        public event EventHandler CanExecuteChanged;
    }
