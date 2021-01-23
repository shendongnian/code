        //Dead-simple implementation of ICommand
        //Serves as an abstraction of Actions performed by the user via interaction with the UI (for instance, Button Click)
        public class Command<T>: ICommand
        {
            public Action<T> Action { get; set; }
    
            public void Execute(object parameter)
            {
                if (Action != null && parameter is T)
                    Action((T)parameter);
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
    
            public Command(Action<T> action)
            {
                Action = action;
            }
        }
