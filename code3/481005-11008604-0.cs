    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FlowDocument fd = new FlowDocument();
            for (int i = 0; i < 1000; i++)
            {
                fd.Blocks.Add(new Paragraph(new Run(i.ToString())));
            }
            view.Document = fd;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (view.Document as FlowDocument) .Blocks.Skip(300).First().BringIntoView();
        }
    }
