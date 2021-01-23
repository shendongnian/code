    public class YourPageViewModel : ViewModelBase
    {
        private ICommand newFunctionCommand;
        public ICommand NewFunctionCommand { get { return newFunctionCommand; } }
        public YourPageViewModel()
        {
            if (DesignMode.DesignModeEnabled) return;
            if (newFunctionCommand == null)
                newFunctionCommand = new ICommand(new Action(NewFunction));
        }
        protected void NewFunction()
        {
        }
    }
