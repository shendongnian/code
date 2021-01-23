    public partial class MainWindow : Window,  INotifyPropertyChanged
    {
        private ObservableCollection<MyModel> _list = new ObservableCollection<MyModel>();
        private MyModel _selectedModel;
    
        public MainWindow()
        {
            InitializeComponent();
            List.Add(new MyModel { Name = "James", CompanyName = "StackOverflow"});
            List.Add(new MyModel { Name = "Adam", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Chris", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Steve", CompanyName = "StackOverflow" });
            List.Add(new MyModel { Name = "Brent", CompanyName = "StackOverflow" });
        }
    
        public ObservableCollection<MyModel> List 
        {
            get { return _list; }
            set { _list = value; }
        }
    
        public MyModel SelectedModel
        {
            get { return _selectedModel; }
            set { _selectedModel = value; NotifyPropertyChanged("SelectedModel"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
