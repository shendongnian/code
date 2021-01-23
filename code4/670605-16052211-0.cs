    <asp:Menu ID="HeaderMenu" runat="server">
        <Items>
        </Items>
    </asp:Menu>
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateMenu();
    }
    protected void PopulateMenu()
    {
        HeaderMenu.Items.Add(new MenuItem 
        {
            "Register Now!",
            "","", 
            "~/Pages/Register.aspx"
        });
    }
