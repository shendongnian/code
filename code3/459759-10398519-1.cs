    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
     {
        if (e.CommandName ="detail")
         {
      int index = Convert.ToInt32(e.CommandArgument);
      List<Something> test = SomeMethod(index);
        }
     }
