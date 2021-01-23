    <asp:GridView ID="grdImages" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:ImageField DataImageUrlField="URL" HeaderText="Image" 
            ControlStyle-Height="150" ControlStyle-Width="120" />
        </Columns>
    </asp:GridView>
    protected void Page_Load(object sender, EventArgs e)
    {
            grdImages.DataSource = yourDataSource;
            grdImages.DataBind();
    }
