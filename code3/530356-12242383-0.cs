    var dtableDemo = new DataTable();
    dtableDemo = this.dgvDemo.DataSource as DataTable; //// Getting the datatable of datagridview datasource
    if (dtableDemo != null)
    {
        dtableDemo.Columns.RemoveAt(0); //// Removing the first column of derived table
    
        dtableDemo.Rows.Cast<DataRow>().Where(
                   row => row.ItemArray.Contains("put_your_value_to_check")).ToList()
                   .ForEach(row => row.Delete()); //// Remove the row if it contains the given value
        dtableDemo.AcceptChanges(); //// Finalize the delete
    }
