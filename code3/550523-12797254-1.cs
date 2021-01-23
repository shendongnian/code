    public partial class MainWindow : Window
    {
        public MyClass Test { get; set; }
        public MainWindow()
        {
            Test = new MyClass();
            InitializeComponent();
            Test.Run();
        }
    }
    public class MyClass
    {
        public Progress MyProgress { get; set; }
        public void Run()
        {
            MyProgress = new Progress();
            MyProgress.Status = "Initialising";
            // Do stuff, update progress, etc.
        }
    }
    public class Progress : INotifyPropertyChanged
    {
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
