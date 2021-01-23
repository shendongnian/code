    protected void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
    {
        if (e.Action == DataRowAction.Add)
        {
            // Do something with e.Row which is already populated
        }
    }
