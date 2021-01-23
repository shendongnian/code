    public partial class MainWindow : Window
    {
        MyTextProducer txtProducer;
        public MainWindow()
        {
            InitializeComponent();
            txtProducer = new MyTextProducer();
            this.DataContext = txtProducer;
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(txtProducer.ProduceText);
            txtBox.Text = txtProducer.myText;
        }
    }
