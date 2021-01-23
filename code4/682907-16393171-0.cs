    public LoginDb()
        {
            InitializeComponent();
            this.Activated += new EventHandler(LoginDb_Activated);
        }
        void LoginDb_Activated(object sender, EventArgs e)
        {
            this.BindData();
        }
        private void BindData()
        {
            MyOleDbConnection.Open();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da = new OleDbDataAdapter("select * from login", MyOleDbConnection.vcon);
            /*da.Fill(dt);
            logindb_dataGridView.DataSource = dt.DefaultView;*/
            da.Fill(dt);
            logindb_dataGridView.DataSource = dt;
            logindb_dataGridView.AutoResizeColumns();
            MyOleDbConnection.Close();
        }
