    <asp:Repeater ID="RepeaterOrderlineInfo" runat="server">
        <ItemTemplate>
            <asp:Label ID="labelDate" runat="server" />
        </ItemTemplate>
    </asp:Repeater>
    RepeaterOrderlineInfo.ItemCreated += Repeater_ItemCreated;
    protected void Repeater_ItemCreated(object sender, RepeatrItemCreatedEventArgs e)
    {
        DataRow dataItem = e.Item.DataItem as DataRow;
        if(dataItem != null)
        {
            Label labelDate = e.Item.FindControl("labelDate") as Label;
            if(labelDate != null && row["Description"] != "TechnicalSupport")
               labelDate.Text = // whatever you want to do
        }
    }
