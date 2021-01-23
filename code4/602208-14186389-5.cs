    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> myVar = new ObservableCollection<string>();
        private DateTime _lastScroll;
        public MainWindow()
        {
            InitializeComponent();
            MouseTouchDevice.RegisterEvents(this);
            for (int i = 0; i < 1000; i++)
            {
                List.Add("StackOverflow " + i);
            }
        }
        public ObservableCollection<string> List
        {
            get { return myVar; }
            set { myVar = value; }
        }
        public bool IsScrolling
        {
            get { return !(DateTime.Now > _lastScroll.AddMilliseconds(100)); }
        }
        private void List_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _lastScroll = DateTime.Now;
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Thread.Sleep(100);
                NotifyPropertyChanged("IsScrolling");
            });
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
