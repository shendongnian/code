    private void hostDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = hostDatagrid[e.ColumnIndex,e.RowIndex].Value.ToString();
            LogFileViewModel logFileViewModel = new LogFileViewModel();
            DataTable table = logFileViewModel.search(cellValue);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            logDataGrid.Datasource = table;
            logDataGrid.Update();
            logDataGrid.Refresh();
        }
       // and add this method to  LogFileViewModel
     public DataTable Search(string hostID)
        {
            DataTable ndt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            sqlcon.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM whatever WHERE hostid ="+hostID, sqlcon);
            da.Fill(ndt);
            da.Dispose();
            sqlcon.Close();
            return ndt;
           
            
        }
