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
            // if you do not use the dispatcher you will get the error "The calling thread cannot access this object because a different thread owns it."
            dataGrid1.Dispatcher.Invoke(new Action(() =>
            {
                dataGrid1.ItemsSource = myList.Select(i => new { Item = i });
            }));
        }
    }
