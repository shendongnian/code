    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand ButtonClickCommand { get; set; }
        private ObservableCollection<string> _fonts;
        public ObservableCollection<string> fonts
        {
            get { return _fonts; }
            set
            {
                _fonts = value;
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("fonts"));
                }
            }
        }
        private string _SelectedFont;
        public string SelectedFont
        {
            get { return _SelectedFont; }
            set
            {
                // Some logic here
                _SelectedFont = value;
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFont"));
                }
              
            }
        }
        public VM()
        {
            this.fonts = new ObservableCollection<string>();
            fonts.Add("Arial");
            fonts.Add("Courier New");
            fonts.Add("Times New Roman");
            ButtonClickCommand = new RelayCommand(Click);
        }
        private void Click()
        {
            new Action(async () => await new Windows.UI.Popups.MessageDialog("Testing dialog").ShowAsync()).Invoke();
        }
    }
