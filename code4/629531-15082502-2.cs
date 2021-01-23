    using System;
    using System.Windows.Input;
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> m_executeAction;
        private readonly Predicate<T> m_canExecutePredicate;
        public DelegateCommand(Action<T> executeAction)
            : this(executeAction, null)
        {
        }
        public DelegateCommand(Action<T> executeAction, Predicate<T> canExecutePredicate)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }
            m_executeAction = executeAction;
            m_canExecutePredicate = canExecutePredicate;
        }
        public event EventHandler Executed;
        public event EventHandler CanExecuteChanged;
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }
        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }
        public bool CanExecute(T parameter)
        {
            var result = true;
            var canExecutePredicate = m_canExecutePredicate;
            if (canExecutePredicate != null)
            {
                result = canExecutePredicate(parameter);
            }
            return result;
        }
        public void Execute(T parameter)
        {
            m_executeAction(parameter);
            RaiseExecuted();
        }
        public void Refresh()
        {
            RaiseCanExecuteChanged();
        }
        protected virtual void RaiseExecuted()
        {
            var handler = Executed;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        protected virtual void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
