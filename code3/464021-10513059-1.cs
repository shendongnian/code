    string template =
    @"<html>
    <body>
    Hi @Model.FirstName @Model.LastName,
    
    Here are your orders: 
    @foreach(var order in Model.Orders) {
        Order ID @order.Id Quantity : @order.Qty <strong>@order.Price</strong>. 
    }
    
    </body>
    </html>";
    
    var model = new OrderModel {
    	FirstName = "Martin",
    	LastName = "Whatever",
    	Orders = new [] {
    		new Order { Id = 1, Qty = 5, Price = 29.99 },
    		new Order { Id = 2, Qty = 1, Price = 9.99 }
    	}
    };
    
    string mailBody = Razor.Parse(template, model);
