    private void addButton_Click(object sender, System.EventArgs e)
    {
        //I'm assuming your datatable is a member level variable 
        //otherwise you could get it through the grid
        //have the datatable send you back a new row
        DataRow newRow = table.NewRow();
        //populate your new row with default data here
        //....
        //add the new row to the data table
        table.Rows.Add(newRow);
    }
