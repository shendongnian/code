    private void ddlEventhistory_SelectionChangeCommitted(object sender, EventArgs e)
    {
        // Assign DataTable of selected ComboBox item to DataGrid.
        dgEvent.DataSource = (ddlEventhistory.SelectedItem as Data).Value as DataTable;
        // You might also try this line.
        dgEvent.DataSource = ddlEventhistory.SelectedValue as DataTable;
    }
