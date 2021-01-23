    private void grdClientServiceType_RowCreated(object sender,   System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Pager)
        {
           // Create your control here, button is an example create whatever you want
           Button theButton = new Button();
           theButton.Text = "Click Me";
           // Add new control to the row with the pager via a table cell
           e.Row.Cells[0].ColumnSpan -= 1;
           TableCell td = new TableCell();
           td.Controls.Add(theButton);
           e.Row.Cells.Add(td);
        }
    }
