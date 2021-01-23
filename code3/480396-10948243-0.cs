    void DataGrid1_SortCommand(Object sender, DataGridSortCommandEventArgs e)
        {
            // Retrieve the data source.
            DataTable dt = YOURDATA;
    
            // Create a DataView from the DataTable.
            DataView dv = new DataView(dt);
    
            // The DataView provides an easy way to sort. Simply set the
            // Sort property with the name of the field to sort by.
            dv.Sort = e.SortExpression;
    
            // Rebind the data source and specify that it should be sorted
            // by the field specified in the SortExpression property.
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }
