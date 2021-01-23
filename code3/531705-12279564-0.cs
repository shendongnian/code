     public ActionResult PrintOrders(string searchString, int searchOrder = 0)
        {
            var user = from m in db.OrderDetails   
                       select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.Order.ClientID.Contains(searchString));               
            }
            if (searchOrder > 0)
            {
                user = user.Where(c => c.Order.OrderId == searchOrder);               
            }
            return this.ViewPdf("Order", "PrintView", user);
        }
