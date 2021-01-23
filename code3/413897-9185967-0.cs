    <asp:CheckBoxList ID="checkBoxList1" runat="server">
        <asp:ListItem>abc</asp:ListItem>
        <asp:ListItem>def</asp:ListItem>
    </asp:CheckBoxList>
    private void SelectCheckBoxList(string valueToSelect)
    {
    	ListItem listItem = this.checkBoxList1.Items.FindByText(valueToSelect);
    
    	if(listItem != null) listItem.Selected = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SelectCheckBoxList("abc");
    }
