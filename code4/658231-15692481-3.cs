    //Dead-simple implementation of ICommand
        //Serves as an abstraction of Actions performed by the user via interaction with the UI (for instance, Button Click)
        public class Command : ICommand
        {
            public Action Action { get; set; }
    
            public void Execute(object parameter)
            {
                if (Action != null)
                    Action();
            }
    
            public bool CanExecute(object parameter)
            {
                return IsEnabled;
            }
    
            private bool _isEnabled;
            public bool IsEnabled
            {
                get { return _isEnabled; }
                set
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                        CanExecuteChanged(this, EventArgs.Empty);
                }
            }
    
            public event EventHandler CanExecuteChanged;
    
            public Command(Action action)
            {
                Action = action;
            }
        }
