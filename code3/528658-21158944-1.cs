    //New Datatable created which will have updated cells
    DataTable dtUpdated=new DataTable();
    //This gives similar schema to the new datatable
    dtUpdated = dtReports.Clone();
    foreach (DataRow row in dtReports.Rows)
    {
        for (int i = 0; i < dtReports.Columns.Count; i++)
        {
            string oldVal = row[i].ToString();
            string newVal = "{"+oldVal;
            row[i] = newVal;
        }
        dtUpdated.ImportRow(row); 
    }
