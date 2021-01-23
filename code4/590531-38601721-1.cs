    public class WindowCommand : ICommand
    {
        private MainWindow _window;
        public Action ExecuteDelegate { get; set; }
        public WindowCommand(MainWindow window)
        {
            _window = window;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
