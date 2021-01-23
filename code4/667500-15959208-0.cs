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
                <asp:HyperLink runat="server" ID="HyperLink1" />
            </li>
        </ItemTemplate>
    </asp:ListView>
    
    public class Menu
    {
        public string Href { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var collection = new List<Menu>
                {
                    new Menu
                        {
                            Href = "General.aspx",
                            Class = "home",
                            Text = "General"
                        },
                    new Menu
                        {
                            Href = "Calendarized.aspx",
                            Class = "calendarized",
                            Text = "Calendarized"
                        }
                };
    
            ListViewMenu.DataSource = collection;
            ListViewMenu.DataBind();
        }
    }
    
    protected void ListViewMenu_ItemDataBound(
        object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            // Cast e.Item.DataItem to appropiate class. 
            // For example, if you use DataSet, cast to DataView.
            // var menu = e.Item.DataItem as DataView;
            var menu = e.Item.DataItem as Menu;
    
            var hyperLink = e.Item.FindControl("HyperLink1") as HyperLink;
            hyperLink.NavigateUrl = menu.Href;
            hyperLink.Text = menu.Text;
            hyperLink.CssClass = menu.Class;
    
            // if (string.Equals(pageName, menu.Href))
            if (Request.Path.ToLower().Contains(menu.Href.ToLower()))
                hyperLink.CssClass += " active";
        }
    }
