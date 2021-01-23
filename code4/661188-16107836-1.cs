    public class BaseViewModel
    {
        ObservableCollection<ViewModels> ViewModels;
        // pass the command from the child's viewModel.
        public ICommand MoveCommand
        {
            get
            {
                return SelectedItem.MoveCommand;
            }
        }
        public SelectedItem ViewModel {get;set;}
        public BaseViewModel()
        {
             
        }
    }
