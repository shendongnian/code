    void GridView1_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
    {
      // Get the currently selected row. Because the SelectedIndexChanging event
      // occurs before the select operation in the GridView control, the
      // SelectedRow property cannot be used. Instead, use the Rows collection
      // and the NewSelectedIndex property of the e argument passed to this 
      // event handler.
      int reviewid = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value); //value of the datakey **strong text**
      
      // Put the logic from btnVote_Click here
    }
