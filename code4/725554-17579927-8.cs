    <asp:GridView ID="gvOrders" AutoGenerateColumns="false" runat="server"
      AllowSorting="true" OnSorting="gvOrders_Sorting">
      <Columns>
        <asp:BoundField DataField="OrderID" SortExpression="OrderID" HeaderText="Order ID" />
        <asp:BoundField DataField="OrderDate" SortExpression="OrderDate" HeaderText="Order Date" />
        <asp:BoundField DataField="TotalPurchaseAmount" SortExpression="TotalPurchaseAmount" HeaderText="Total Purchase Amount" />
        <asp:BoundField DataField="Comments" SortExpression="Comments" HeaderText="Comments" />
        <asp:BoundField DataField="Shipped" SortExpression="Shipped" HeaderText="Shipped" />
      </Columns>
    </asp:GridView>
