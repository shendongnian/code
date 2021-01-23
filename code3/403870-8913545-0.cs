    <asp:TextBox ID="textBox1" runat="server">
    </asp:TextBox>
    <asp:CheckBoxList ID="Numbers" runat="server" 
                       OnSelectedIndexChanged="UpdateCheckBoxex" AutoPostBack="true">
        <asp:ListItem Text="One" Value="One" />
        <asp:ListItem Text="Two" Value="Two" />
        <asp:ListItem Text="Three" Value="Three" />
        <asp:ListItem Text="Four" Value="Four" />
    </asp:CheckBoxList>
    protected void UpdateCheckBoxex(object sender, EventArgs e)
    {
        string s = string.Empty;
        new List<ListItem>(Numbers.Items.Cast<ListItem>().Where(i => i.Selected)).ForEach(x => s += string.Format("{0}, ", x.Text));
        textBox1.Text = s;        
    }
