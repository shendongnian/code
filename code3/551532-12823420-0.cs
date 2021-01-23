     private void doMore(DataTable dt)
        {
        foreach(DataColumn dc in dt.Columns)
        {
        MessageBox.Show(dc.ColumnName);
        }
        }
