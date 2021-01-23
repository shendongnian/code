    private void hostDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString();
            DataTable table = Datamodel.getData(cellValue);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            logDataGrid.Datasource = table;
            logDataGrid.Update();
            logDataGrid.Refresh();
        }
       // Change your GetData to something like this :
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
