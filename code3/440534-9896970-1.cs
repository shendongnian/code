    protected void GridView1_RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow currentRow = ((GridView)sender).Rows[e.RowIndex];
        String intColumnText = currentRow.Cells[0].Text; //assuming it's the first cell
        int value;
        if(int.TryParse(intColumnText, out value))
        {
            //do something
        } 
    }
