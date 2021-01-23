    public class Command : ICommand
    {
        private readonly ViewModel _viewModel;
        public Command(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public void Execute(object parameter)
        {
            var dataOnControlOne = _viewModel.TextBoxOnUserControlOne;
            var dataOnControlTwo = _viewModel.TextBoxOnUserControlTwo;
            //Use these values
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
