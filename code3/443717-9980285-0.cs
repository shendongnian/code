    public partial class MainWindow : Window
    {
        public List<string> myList { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            myList = new List<string>();
            label1.Content = Thread.CurrentThread.ManagedThreadId.ToString();
            
            Task.Factory.StartNew(PrintThreadID);
            Task.Factory.StartNew(Test);
           
        }
        private void PrintThreadID()
        {
            label1.Dispatcher.Invoke(new Action(() =>
                label1.Content += "..." + Thread.CurrentThread.ManagedThreadId.ToString()));
        }
        private void Test()
        {
            myList.Add("abc");
            myList.Add("abc");
            myList.Add("abc");
            dataGrid1.Dispatcher.Invoke(new Action(() =>
            {
                dataGrid1.ItemsSource = myList.Select(i => new { Item = i });
            }));
        }
    }
