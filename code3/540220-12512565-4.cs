    public class SimpleCommand : System.Windows.Input.ICommand
    {
        public SimpleCommand(Action action)
        {
            this.Action = action;
        }
        public Action Action { get; set; }
        public bool CanExecute(object parameter)
        {
            return (this.Action != null);
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            if (this.Action != null)
            {
                this.Action();
            }
        }
    }
