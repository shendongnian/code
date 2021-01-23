    public class MyCommand : ICommand
    {
        bool canExecute;
        public void Execute(object parameter)
        {
            Console.WriteLine("Execute called!");
        }
        public bool CanExecute(object parameter)
        {
            Console.WriteLine("CanExecute called!");
            return CanExecuteResult;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecuteResult
        {
            get { return canExecute; }
            set {
                if (canExecute != value)
                {
                    canExecute = value;
                    var canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                        canExecuteChanged.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
