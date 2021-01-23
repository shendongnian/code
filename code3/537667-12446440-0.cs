    Order_Details.Take(1).Select(od =>
        new Order_Detail
        {
            Order = new Order
            {
                Customer = od.Order.Customer
            },
            Product = new Product
            {
                Order_Details = od.Product.Order_Details
            },
        });
