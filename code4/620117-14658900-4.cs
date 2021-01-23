    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Class1 c1 = new Class1();
        private ABC _abcClass = new ABC();
        public MainWindow()
        {
            InitializeComponent();
            class1.Name = "Class 1";
            _abcClass.Name1 = "ABC Class";
        }
        public ABC ABCClass
        {
            get { return _abcClass; }
            set { _abcClass = value; INotifyChanged("ABCClass"); }
        }
        public Class1 class1
        {
            get { return c1; }
            set { c1 = value; INotifyChanged("class1"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void INotifyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
