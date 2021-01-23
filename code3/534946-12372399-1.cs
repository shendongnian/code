          public class RelayCommand : ICommand
            {
                #region Constants and Fields
        
        
                private readonly Predicate<object> canExecute;
        
        
                private readonly Action<object> execute;
        
                #endregion
        
                #region Constructors and Destructors
        
        
                public RelayCommand(Action<object> execute)
                    : this(execute, null)
                {
                }
        
                public RelayCommand(Action<object> execute, Predicate<object> canExecute)
                {
                    if (execute == null)
                    {
                        throw new ArgumentNullException("execute");
                    }
        
                    this.execute = execute;
                    this.canExecute = canExecute;
                }
        
                #endregion
        
                #region Events
        
        
                public event EventHandler CanExecuteChanged
                {
                    add
                    {
                        CommandManager.RequerySuggested += value;
                    }
        
                    remove
                    {
                        CommandManager.RequerySuggested -= value;
                    }
                }
        
                #endregion
        
                #region Implemented Interfaces
        
                #region ICommand
        
        
                [DebuggerStepThrough]
                public bool CanExecute(object parameter)
                {
                    return this.canExecute == null || this.canExecute(parameter);
                }
        
                public void Execute(object parameter)
                {
                    this.execute(parameter);
                }
        
                #endregion
        
                #endregion
            }
