    public class ViewModelBase
    {
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), ()=> CanExecute));
            }
        }
         public bool CanExecute
         {
            get
            {
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
                return true/false;
            }
         }
        public void MyAction()
        {
    
        }
    }
