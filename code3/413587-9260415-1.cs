    <asp:Repeater runat="server" ID="RepProductMenu" >
    <ItemTemplate>
          <asp:Button ID="BtnDelete" runat="server" Text="Slet" CommandName="DeleteProduct" CommandArgument='<%# Eval("ID") %>' />
    </ItemTemplate>
    </asp:repeater>
    protected void OnItemCommand(Object Sender, CommandEventArgs e)
    {
        if (e.CommandName == "DeleteProduct")
        {
            DataAccess dataAccess = new DataAccess();
    
            int ID = Int32.Parse(e.CommandArgument.ToString());
            dataAccess.AddParameter("@id", ID);
            dataAccess.Execute(@"DELETE FROM [Product] WHERE ID = @ID");
            //Response.Write("COMMAND");
        }
    }
