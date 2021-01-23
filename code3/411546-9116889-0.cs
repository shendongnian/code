    public mainForm()
            {
                InitializeComponent();
                SqlConnection conn = new SqlConnection("Data Source=DBELL;Initial Catalog=part_table;Integrated Security=True");
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT part_num from customParts", conn);
                adapter.Fill(ds);
                this.listParts.DataSource = ds.Tables[0]; 
            }
