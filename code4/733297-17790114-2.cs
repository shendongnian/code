    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
      //
      // Get the keys from the selected row
      //
      LinkButton lnkBtn = (LinkButton)e.CommandSource;    //the button
      GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  //the row
      GridView myGrid = (GridView)sender; // the gridview
      int reviewid = Convert.ToInt32(GridView1.DataKeys[myRow.RowIndex].Value); //value of the datakey **strong text**
    
      // If multiple buttons are used in a GridView control, use the
      // CommandName property to determine which button was clicked.
      // In this case you are pressing the button Select, as ou already
      // defined this at the aspx code.
      if(e.CommandName=="Select")
      {
        // Put the logic from btnVote_Click here
      }
    }
