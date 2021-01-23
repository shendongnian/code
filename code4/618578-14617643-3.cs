    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private User _newUser = new User();
    
        public Window1()
        {
            InitializeComponent();
        }
    
        public User NewUser
        {
            get { return _newUser; }
            set { _newUser = value; NotifyPropertyChanged("NewUser"); }
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
