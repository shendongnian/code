    void Item_Bound(Object sender, DataGridItemEventArgs e) 
    {
          if((e.Item.ItemType == ListItemType.Item) || 
                 (e.Item.ItemType == ListItemType.AlternatingItem))
             {
                 var control = (Label)e.Item.FindControl("YourLabel");
                 control.Text="pass your value";
             }
    }
    <asp:DataGrid id="DataGrid1" 
       runat="server" 
       AutoGenerateColumns="False" OnItemDataBound="Item_Bound">
       <Columns>
          <asp:TemplateColumn HeaderText="Sample">
             <ItemTemplate>
                <asp:Label id="YourLabel" runat="server"/>
             </ItemTemplate>
          </asp:TemplateColumn>
       </Columns>
    </asp:DataGrid>
