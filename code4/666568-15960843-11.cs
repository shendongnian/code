    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(SettingsPage model)
        {
            this.Model = model;
        }
        public SettingsPage Model { get; private set; }
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
