    protected void GridView1_RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow currentRow = ((GridView)sender).Rows[e.RowIndex];
        String intColumnText = currentRow.Cells[5].Text; //assuming it's the first cell
        int value;
        if(int.TryParse(intColumnText, out value))
        {
            //if you want to increment that value and override the old
            currentRow.Cells[5].Text = (value++).ToString();
        } 
    }
