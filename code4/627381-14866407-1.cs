    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            MyProperty = "Hello";
            MyObject = new ObjectTest { MyProperty = "Hello" };
        }
        private dynamic myVar;
        public dynamic MyProperty
        {
            get { return myVar; }
            set { myVar = value; NotifyPropertyChanged("MyProperty"); }
        }
        private dynamic myObject;
        public dynamic MyObject
        {
            get { return myObject; }
            set { myObject = value; NotifyPropertyChanged("MyObject"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
    public class ObjectTest
    {
        public string MyProperty { get; set; }
    }
