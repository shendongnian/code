       public class DCommand :ICommand
        {
        public void FirePropertyChanged()
        {
            if (CanExecuteChanged!=null)
            CanExecuteChanged(this, EventArgs.Empty);            
        }
        Func<bool> CanExecuteFunc { get; set; }
        Action<object> Action { get; set; }
        public DCommand(Action<object> executeMethod)
        {
            this.Action = executeMethod;            
        }
        public DCommand(Action executeMethod)
        {
            this.Action = new Action<object>(
                (prm) =>
                {
                    executeMethod.Invoke();
                }
                );
        }
        public DCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod)
        {            
            this.CanExecuteFunc = canExecuteMethod;            
        }
        public DCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod)
        {
            this.CanExecuteFunc = canExecuteMethod;
        }
        public bool CanExecute(object parameter=null)
        {
            if (CanExecuteFunc == null)
                return true;
            return CanExecuteFunc.Invoke();
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter=null)
        {
            if (CanExecuteFunc == null || CanExecute(parameter))
            {
                Action.Invoke(parameter);                
            }
        }
    }
