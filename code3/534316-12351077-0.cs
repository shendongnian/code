        protected void rptToogle_ItemBound(Object Sender, RepeaterItemEventArgs e)
        {
            try
            {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int year = Convert.ToInt32(drv["Year"]);
                Panel pnl = (Panel)e.Item.FindControl("pnlNext");
    // You code
    
            }
                }
            catch (Exception ex)
            {
                throw ;
            }
        }
    
    
        <asp:Repeater id="rptToogle" runat="server" OnItemDataBound="rptToggle_ItemBound">
            <ItemTemplate>
                <asp:Button id="btnToogle" runat="server" Text=""></asp:Button>
                <div id="divToogle" runat="server" style="display:none;">
                     asdasd, asdasd, asdasd
                </div>
            </ItemTemplate>
        </asp:Repeater>
