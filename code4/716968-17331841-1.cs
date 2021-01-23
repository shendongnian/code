    <asp:CheckBoxList runat="server" ID="CheckBoxList1">
        <asp:ListItem Text="One" Value="1" />
        <asp:ListItem Text="Two" Value="2" />
        <asp:ListItem Text="Three" Value="3" />
    </asp:CheckBoxList>
    <asp:Button runat="server" ID="Button1" Text="Submit" OnClick="Button1_Click" />
        
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                string text = item.Text;
                string value = item.Value;
                // Do something
            }
        }
    }
