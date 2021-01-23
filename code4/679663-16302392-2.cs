    public partial class MainWindow : Window
    {
        public ObservableCollection<String> urls { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            urls = new ObservableCollection<string>();
            this.DataContext = this;
            loadURLsFirstTime();
           
        }
        public void loadURLsFirstTime()
        {
            urls.Add("www.First.com");
            urls.Add("www.Second.com");
            urls.Add("www.Third.com");
            urls.Add("www.Fourth.com");
        }
        public void reverseUrls()
        {
            Stack<String> stack1 = new Stack<string>();
            foreach (String item in urls)
            {
                stack1.Push(item);
            }
            urls.Clear();
            foreach (String item in stack1)
            {
                urls.Add(item);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reverseUrls();
        }
    }
