    <asp:ListView ID="ListViewMenu" runat="server" 
        OnItemDataBound="ListViewMenu_ItemDataBound"
        ItemPlaceholderID="menuContainer">
        <LayoutTemplate>
            <ul class="menu" id="responsive" runat="server">
                <asp:PlaceHolder ID="menuContainer" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" ID="HyperLink1" >
                   <i class='<%#Eval ("class") %>'></i><%#Eval ("text") %>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
    </asp:ListView>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateMenu();
        }
    }
    
    protected void ListViewMenu_ItemDataBound(
        object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var item = e.Item.DataItem as DataRowView;
    
            var hyperLink = e.Item.FindControl("HyperLink1") as HyperLink;
            hyperLink.NavigateUrl = item.Row["href"].ToString();
            hyperLink.CssClass = item.Row["menu"].ToString();
    
            if (Request.Path.ToLower().Contains(item.Row["href"].ToString()))
                hyperLink.CssClass += " active";
        }
    }
    void PopulateMenu()
    {
        DataAccess da = new DataAccess();
        da.AddParameter("ID", ID, DataAccess.SQLDataType.SQLInteger, 4);
        SiteMenu = da.runSPDataSet("Portal_MenuCreate");
        ListViewMenu.DataSource = SiteMenu;
        ListViewMenu.DataBind();
    }
