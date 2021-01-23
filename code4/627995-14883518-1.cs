    public class ApplicationViewModel
    {
        public ObservableCollection<App> AppCollection { get; set; }
        private string searchString;
        private string emailString;
        public App SelectedApp { get; set; }
        public string AppToSearch
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
            }
        }
        public string AppToRequest
        {
            get
            {
                return emailString;
            }
            set { emailString = value; }
        }
        private ICommand searchButtonCmd;
        private ICommand clearButtonCmd;
        private ICommand emailButtonCmd;
        public ApplicationViewModel()
        {
            this.AppCollection = ApplicationsModel.Current;
        }
        public ICommand SearchButtonPressed
        {
            get
            {
                if (this.searchButtonCmd == null)
                {
                    this.searchButtonCmd = new RelayCommand(SearchButtonPressedExecute, c=>CanSearch);
                }
                return this.searchButtonCmd;
            }
        }
        private void SearchButtonPressedExecute(object parameter)
        {
            ApplicationsModel.Current.Search(searchString);
        }
        public bool CanSearch
        {
            get { return true; }
        }
        // TODO: You can figure out the rest of the code
    }
