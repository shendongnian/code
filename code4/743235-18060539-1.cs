    public partial class MainWindow : INotifyPropertyChanged
    {
        private string firstString;
        private string secondString;
        private string thirdString;
        private string fourthString;
        public string FirstString
        {
            get { return firstString; }
            set
            {
                firstString = value;
                RaisePropertyChanged("FirstString");
            }
        }
        public string SecondString
        {
            get { return secondString; }
            set
            {
                secondString = value;
                RaisePropertyChanged("SecondString");
            }
        }
        public string ThirdString
        {
            get { return thirdString; }
            set
            {
                thirdString = value;
                RaisePropertyChanged("ThirdString");
            }
        }
        public string FourthString
        {
            get { return fourthString; }
            set
            {
                fourthString = value;
                RaisePropertyChanged("FourthString");
            }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            FirstString = "First";
            SecondString = "Second";
            ThirdString = "Third";
            FourthString = "Fourth";
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;
            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
