     private SqlConnection con;
     private SqlConnectionStringBuilder str;
    private void Form8_Load(object sender, EventArgs e)
            {
                loadData();
            }
    
            private void loadData()
            {
                str = new SqlConnectionStringBuilder();
                str.Provider = "";
                str.DataSource = @"source.accdb";
                con = new SqlConnection(str.ConnectionString);
                dataGridView1.DataSource = fillTable("Select* from yourTable");
            }
    
            private DataTable fillTable(string sql)
            {
                DataTable datatable = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(datatable);
                }
    
                return datatable;
            }
