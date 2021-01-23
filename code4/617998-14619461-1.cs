    public partial class MainWindow : Window
    {
        Thread th;
        static ObservableCollection<string> data;
        public MainWindow()
        {
            InitializeComponent();
            data = new ObservableCollection<string>();
            lst.ItemsSource = data;
            th = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    { data.Add("zzzzzz"); }));
                }
            });
            th.Start();
        }
    }
