    public class HelloWorldCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString());
        }
    }
