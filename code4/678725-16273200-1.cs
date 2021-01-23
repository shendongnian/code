    public class MainViewModel
    {
        public MainViewModel()
        {
            NextViewCommand = new DelegateCommand(NextView);
        }
        public ICommand NextViewCommand {get;set;}
        public UserControl NewView {get;set;}
        public void NextView()
        {
             NewView = new UserControl() //set your NewView property to your new usercontrol 
             //Apply validation on all your binded properties you want to validate.
        }
    }
