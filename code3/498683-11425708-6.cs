    public class CalibrateCommand : ICommand
    {
        private ViewModel viewModel;
        public CalibrateCommand(ViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public void Execute(object parameter)
        {
            viewModel.IsClicked = true;
        }
        public bool CanExecute()
        {
            return true;
        }
    }
