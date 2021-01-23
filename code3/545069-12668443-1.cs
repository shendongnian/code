    public class PositioningCommand : ICommand
    {
        Action<object> _executeDelegate;
        public PositioningCommand()
        {
        }
        public void Execute(object parameter)
        {
            Point mousePos = Mouse.GetPosition((IInputElement)parameter);
            Console.WriteLine("Position: " + mousePos.ToString());
        }
        public bool CanExecute(object parameter) { return true; }
        public event EventHandler CanExecuteChanged;
    }
    public PositioningCommand TargetClick
    {
        get;
        internal set;
    }
