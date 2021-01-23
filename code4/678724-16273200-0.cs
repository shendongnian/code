    public class MainViewModel
    {
        public MainViewModel()
        {
            NextViewCommand = new DelegateCommand(NextView);
        }
        public ICommand NextViewCommand {get;set;}
        public void NextView()
        {
             //Your navigation logic with validation.
        }
    }
