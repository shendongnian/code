        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Enabled="false" />
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_OntTextChanged" />
    protected void TextBox1_OntTextChanged(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length > 0)
        {
            Button1.Enabled = true;
        }
        else
        {
            Button1.Enabled = false;
        }
    }
