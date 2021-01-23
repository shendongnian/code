    private void grdClientServiceType_RowCreated(object sender,   System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Pager)
        {
           // Create your control here, button is an example create whatever you want
           Button theButton = new Button();
           theButton.Text = "Click Me";
           // Add new control to the row with the pager
           e.Row.Cells.Add(theButton);
        }
    }
