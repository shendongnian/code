    private void TestAndRemoveColumn(string dcName,DataTable datatable)
    {
        DataTable dt = datatable; 
        dt.Columns.Remove("dcName");      
    }
