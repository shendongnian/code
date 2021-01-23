    public class ActionCommand : ICommand
    {
        private readonly Action _action;
        public ActionCommand(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _action();
        }
        // not used
        public event EventHandler CanExecuteChanged;
    }
