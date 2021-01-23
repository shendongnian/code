    public partial class MainWindow : Window
    {
        public DataTable MyTable { get; set; }
        public MainWindow()
        {
            InitializeComponent();
           
            this.MyTable= new DataTable();
            this.MyTable.Columns.Add("Test");
            var row1 = this.MyTable.NewRow();
            row1["Test"] = "dsjfks";
            this.MyTable.Rows.Add(row1);
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("rows: " + this.MyTable.Rows.Count);
        }
    }
