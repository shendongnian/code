    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _myText;
        public string myText { 
          get{return _myText;}
          set{_myText = value;
             if(PropertyChanged!=null) PropertyChanged(this, new PropertyChangedEventArgs("myText")) ;
          }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        etc.....
    }
