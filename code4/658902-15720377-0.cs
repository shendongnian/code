    @{
        Layout = "~/_Layout.cshtml";
        Page.Title = "WebGrid.Table method";
    
        var db = Database.Open("Northwind");
        var sql = "SELECT OrderId FROM Orders";
        var orders = db.Query(sql).Select(o => new SelectListItem {
            Value = o.OrderId.ToString(), 
            Text = o.OrderID.ToString(),
            Selected = o.OrderID.ToString() == Request["OrderID"]
        });
    
        WebGrid grid = null;
        var orderTotal = 0f;
    
        if(IsPost){
            sql = @"SELECT p.ProductName, o.UnitPrice, o.Quantity, 
                    (o.UnitPrice * o.Quantity) - (o.UnitPrice * o.Quantity * o.Discount) As TotalCost 
                    FROM OrderDetails o INNER JOIN Products p ON o.ProductID = p.ProductID 
                    WHERE o.OrderID = @0";
            
            var orderDetails = db.Query(sql, Request["OrderID"]);
            orderTotal = orderDetails.Sum(o => (float)o.TotalCost);
    
            grid = new WebGrid(orderDetails, canPage: false, canSort: false);
        }
    }
    <h1>@Page.Title</h1>
    <form method="post">
        @Html.DropDownList("OrderID", orders)
        <input type="Submit" value="Get Products" /><br/> <br/> 
    </form>
    
    @if(grid != null){
        @grid.Table(
                columns: grid.Columns(
                    grid.Column("ProductName", "Product", style: "_220"),
                    grid.Column("UnitPrice", "Price", style: "_60", format: @<text>@item.UnitPrice.ToString("c")</text>),
                    grid.Column("Quantity", style: "_90"),
                    grid.Column("TotalCost", "Total Cost", style: "_90", format: @<text>@item.TotalCost.ToString("c")</text>)
                ), 
                footer: @<table class="footer">
                             <tr>
                                 <td class="_220">Total</td>
                                 <td colspan="2" class="_150">&nbsp;</td>
                                 <td class="_90">@orderTotal.ToString("c")</td>
                             </tr>
                        </table>);
    }
