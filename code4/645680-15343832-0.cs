    public partial class MainWindow : Window
    {
        private List<String> list = new List<string>();
        public List<String> List { get { return this.list; } set { this.list = value; } }
        public MainWindow()
        {
            InitializeComponent();
            list.Add("methode");
            list.Add("methode");
            list.Add("methode");
            list.Add("methode2");
            list.Add("methode2");
            this.DataContext = this;
        }
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedIndex.ToString());
        }
    }
