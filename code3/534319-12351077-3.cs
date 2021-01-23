        protected void rptToogle_ItemBound(Object Sender, RepeaterItemEventArgs e)
        {
            try
            {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int year = Convert.ToInt32(drv["Year"]);
                Panel pnl = (Panel)e.Item.FindControl("pnlToggle");
            // Your code
    
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
                   <asp:Panel ID="pnlToggle" runat="server" Visible="false">
                     //Use Panel as this also need unique ID for your code to work properly
                    </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
