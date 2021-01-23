    void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        //You can try with Command Name.
        if(e.CommandName=="Update")
        {
          .....  
        }
        //You can also try with sender parameter
        var control = (Button)sender;
        if(control.Id = "YourId")
        {
          .....
        } 
    }
