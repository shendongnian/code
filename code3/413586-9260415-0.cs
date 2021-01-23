    <asp:Repeater runat="server" ID="RepProductMenu" OnItemCommand="RepProducts_ItemCommand">
    <ItemTemplate>
          <asp:Button ID="BtnDelete" runat="server" Text="Slet" CommandName="DeleteProduct" CommandArgument='<%# Eval("ID") %>' />
    </ItemTemplate>
    </asp:repeater>
                        
   
     protected void RepProducts_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteProduct")
            {
                int ID = Int32.Parse(e.CommandArgument.ToString());
                // Add Delete Query
                Response.Write("COMMAND");
            }
        }      
