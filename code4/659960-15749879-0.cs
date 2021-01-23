    <style type="text/css">
        td div { margin-right: 5px; }
        td div input {border: 1px solid #828282; height: 21px; }
        td div span { line-height: 25px; }
    </style>
    
    <asp:Table ID="tblDisplayTable" runat="server" CellPadding="0" CellSpacing="0">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Panel ID="pnlPrizeNumberLabel" runat="server" Width="80px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:Panel ID="pnlPrizeDropDownList" runat="server" Width="130px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlNickNameLabel" runat="server" Width="70px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlPrizeNicknameTextBox" runat="server" Width="125px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlFirstNameLabel" runat="server" Width="70px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlLastNameLabel" runat="server" Width="70px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlEmailAddressLabel" runat="server" Width="140px">
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Panel ID="pnlAddButton" runat="server" Width="40px">
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i < 10; i++)
        {
            string ID = i.ToString();
            TextBoxLabel(ID);
            PopulatePrizeNicknameLabel(ID);
            PopulateFirstNameLabel(ID);
            PopulateLastNameLabel(ID);
        }
    }
    
    protected void TextBoxLabel(string ID)
    {
        TextBox lbl = new TextBox();
        lbl.Width = 65;
        lbl.Text = "";
        lbl.ID = "TextBox_" + ID;
        lbl.Text = ID;
        pnlNickNameLabel.Controls.Add(lbl);
    }
    
    protected void PopulatePrizeNicknameLabel(string ID)
    {
        Label lbl = new Label();
        lbl.Width = 125;
        lbl.Text = "";
        lbl.BackColor = System.Drawing.Color.Green;
        lbl.ID = "PrizeNickname_" + ID;
        lbl.Text = ID;
        pnlPrizeNicknameTextBox.Controls.Add(lbl);
    }
    
    protected void PopulateLastNameLabel(string ID)
    {
        Label lbl = new Label();
        lbl.Width = 70;
        lbl.Text = "";
        lbl.BackColor = System.Drawing.Color.Red;
        lbl.ID = "lastname_" + ID;
        lbl.Text = ID;
        pnlLastNameLabel.Controls.Add(lbl);
    }
    
    protected void PopulateFirstNameLabel(string ID)
    {
        Label lbl = new Label();
        lbl.Width = 70;
        lbl.Text = "";
        lbl.BackColor = System.Drawing.Color.Blue;
        lbl.ID = "firstname_" + ID;
        lbl.Text = ID;
        pnlFirstNameLabel.Controls.Add(lbl);
    }
