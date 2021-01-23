    public class MyViewModel
    {
        public MyCommand ActionCommand
        {
            get;
            set;
        }
        public MyViewModel()
        {
            ActionCommand = new MyCommand();
            ActionCommand.CanExecuteFunc = obj => true;
            ActionCommand.ExecuteFunc = MyActionFunc;
        }
        public void MyActionFunc(object parameter)
        {
            // Do stuff here 
        }
    }
    public class MyCommand : ICommand 
    {
        public Predicate<object> CanExecuteFunc
        {
            get;
            set;
        }
        public Action<object> ExecuteFunc
        {
            get;
            set;
        }
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            ExecuteFunc(parameter);
        }
    }
