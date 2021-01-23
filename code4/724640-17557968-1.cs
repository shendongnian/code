    void MyGridView(Object sender, GridViewCommandEventArgs e)
    {
      // If multiple buttons are used in a GridView control, use the
      // CommandName property to determine which button was clicked.
      if(e.CommandName=="my command name")
      {
         //Do stuff here
      }
    }
