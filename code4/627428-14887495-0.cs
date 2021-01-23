    private void Form6_Load(object sender, EventArgs e)
            {
                loadData();
            }
    
    private void loadData()
                {
                    str = new OleDbConnectionStringBuilder();
                    str.Provider = "Microsoft.ace.Oledb.12.0";
                    str.DataSource = @"\\sisc-erelim\4_Printing\VTDB\DB\VirginiTEADB2.accdb";
                    con = new OleDbConnection(str.ConnectionString);
                    dataGridView1.DataSource = fillTable("Select* from Accountstbl");
                    dataGridView1.Columns["Password"].Visible = false;
                    dataGridView1.Columns["Picture"].Visible = false;
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
