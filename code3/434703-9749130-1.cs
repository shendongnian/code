    <asp:Panel ID="Panel1" runat="server">
                <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
    </asp:Panel>
     protected void Page_Load(object sender, EventArgs e)
    {
        ClearTextBoxes(Panel1);
    }
    protected void ClearTextBoxes(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c is TextBox && c.ID.StartsWith("txt"))
                ((TextBox)c).ReadOnly = true;
        }
    }
