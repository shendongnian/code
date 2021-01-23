    private void hostDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = hostDatagrid[e.ColumnIndex,e.RowIndex].Value.ToString();
            LogFileViewModel logFileViewModel = new LogFileViewModel();
            DataTable table = logFileViewModel.getData(cellValue);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            logDataGrid.Datasource = table;
            logDataGrid.Update();
            logDataGrid.Refresh();
        }
       // Change your GetData to something like this or creat another method like this that works like a search method. use your own connection methods if they work fine :
     public DataTable GetData(string hostID)
        {
            SqlConnection conn = new SqlConnection(@"your connection string here");
           
            SqlCommand cmd = new SqlCommand("SELECT * FROM whatever WHERE id ="+hostID, conn);
           
            conn.Open();
            DataTable datatable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(datatable);
            conn.Close();
            return datatable;
        }
