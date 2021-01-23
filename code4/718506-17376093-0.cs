    protected void DetailsView1_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {
        // Use the CommandName property to determine which button
        // was clicked. 
        if (e.CommandName == "btnSelectAll")
        {
            // You may need to tweak this as I almost never use DetailsView, but the concept should work
            // Check the Apples checkbox
            // Apples is the first row (index 0) and second cell (index 1)
            DetailsViewRow row = DetailsView1.Rows[0];
            (row.Cells[1] as CheckBox).Checked = true;
            // Check the Oranges checkbox
            // Apples is the second row (index 1) and second cell (index 1)
            DetailsViewRow row = DetailsView1.Rows[1];
            (row.Cells[1] as CheckBox).Checked = true;
            // Keep moving through the rows...
        }
    }
