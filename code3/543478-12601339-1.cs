    <asp:LinkButton ID="Details"  commandname="Details" runat="server" Text="Details"></asp:LinkButton>
    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if(e.CommandName=="Details")
        {
         // Convert the row index stored in the CommandArgument
         // property to an Integer.
         int index = Convert.ToInt32(e.CommandArgument);
        //Your Code
    
        }
    
    }
