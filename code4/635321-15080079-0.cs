     private OleDbConnection con;
     private OleDbConnectionStringBuilder str;
    private void Form8_Load(object sender, EventArgs e)
            {
                loadData();
            }
    
            private void loadData()
            {
                str = new OleDbConnectionStringBuilder();
                str.Provider = "Microsoft.ace.Oledb.12.0";
                str.DataSource = @"source.accdb";
                con = new OleDbConnection(str.ConnectionString);
                dataGridView1.DataSource = fillTable("Select* from yourTable");
            }
    
            private DataTable fillTable(string sql)
            {
                DataTable datatable = new DataTable();
                using (OleDbDataAdapter da = new OleDbDataAdapter(sql, con))
                {
                    da.Fill(datatable);
                }
    
                return datatable;
            }
