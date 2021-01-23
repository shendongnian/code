    <asp:GridView ID="grdImages" runat="server" AutoGenerateColumns="false">
        <Columns>
            
          <asp:ImageField DataImageUrlField="URL" NullDisplayText="Text when no image."/>
        </Columns>
    </asp:GridView>
    protected void Page_Load(object sender, EventArgs e)
    {
            grdImages.DataSource = yourDataSource;
            grdImages.DataBind();
    }
