    <telerik:GridTemplateColumn HeaderText="Foobar">
         <ItemTemplate>
              <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="true"
                   OnSelectedIndexChanged="DropDownList1_OnSelectedIndexChanged">
                   <asp:ListItem Text="First" Value="1" />
                   <asp:ListItem Text="Second" Value="2" />
                   <asp:ListItem Text="Third" Value="3" />
              </asp:DropDownList>
              <asp:HiddenField runat="server" ID="HiddenField1" />
         </ItemTemplate>
    </telerik:GridTemplateColumn>
    
    protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var gridDataItem  = ((Control)sender).BindingContainer as Telerik.Web.UI.GridDataItem;
        if (gridDataItem != null)
        {
            var hiddenField = gridDataItem.FindControl("HiddenField1") as HiddenField;
        }
    }
