        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                con = new SqlConnection("Data Source=ComputerName;Initial Catalog=YourDBName;Persist Security Info=True;");
                con.Open();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter da = null;
            DataSet ds = null;
            try
            {
                da = new SqlDataAdapter("select * from YourTableName",con);
                da.SelectCommand.CommandTimeout = 100000;
                ds = new DataSet();
                da.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
