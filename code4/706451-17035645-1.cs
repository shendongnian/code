    public class MyViewModel: ViewModelBase
    {
        public string SearchText {get;set;} //NotifyPropertyChanged, etc.
    
        public Command SearchCommand {get;set;}
    
        public MyViewModel()
        {
            //Instantiate command
            SearchCommand = new DelegateCommand(OnSearch);
        }
    
        private void OnSearch()
        {
            //... Execute search based on SearchText
        }
    }
