    <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%#Eval("LinkID")%>' CommandName="btnUpdate" Text='<%#Eval("LinkDisplayText")%>'>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="btnUpdate")
        {
          int index = Convert.ToInt32(e.CommandArgument);
          //based on LinkID get the current click count from database.
          int icount;
          //increment the count
          //update the database once again and get the link as well.
          //redirect to the link
          Response.Redirect("");
        }
      }
