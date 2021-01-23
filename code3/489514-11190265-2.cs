    class Command : ICommand
    {
        Action CallBack = null;
        public Command(Action cb)
        {
            CallBack = cb;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            CallBack();
        }
    }
