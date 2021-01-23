    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(HomePage model)
        {
            this.Model = model;
        }
        public HomePage Model { get; private set; }
        public string PageTitle
        {
            get
            {
                return this.Model.PageTitle;
            }
            set
            {
                this.Model.PageTitle = value;
                this.OnPropertyChanged("PageTitle");
            }
        }
    }
