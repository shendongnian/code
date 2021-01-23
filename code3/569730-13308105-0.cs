    namespace backWorkerTest
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet dataSet = new DataSet();
        BackgroundWorker backWorker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            dataSet.Tables.Add("Stores");
            
            backWorker.DoWork += new DoWorkEventHandler(backWorker_DoWork);
            backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorker_RunWorkerCompleted);
            backWorker.RunWorkerAsync();
        }
        #region Fill dataSet
        void GetData()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CN-LT08\Nick;Initial Catalog=SorterAdmin;" +
                                                         "User=sa; Password=Altrincham09"))
            {
                SqlDataAdapter sql = new SqlDataAdapter("SELECT [Store Number], [Store Name] FROM [Store_Info]", con);
                DataTableMapping mapping = sql.TableMappings.Add("Table", "Stores");
                mapping.ColumnMappings.Add("Store Number", "Test");
                mapping.ColumnMappings.Add("Store Name", "Test2");
                con.Open();
                sql.FillSchema(dataSet, SchemaType.Mapped);
                sql.Fill(dataSet);
                con.Close();
            }
        }
        #endregion
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            backWorker.RunWorkerAsync();
        }
        private void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dataSet.Clear();
            GetData();
        }
        private void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listView1.ItemsSource = dataSet.Tables["Stores"].DefaultView;
            listView1.Items.Refresh();
            //MessageBox.Show("Complete");
        }
    }
