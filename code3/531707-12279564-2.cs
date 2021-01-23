        public ActionResult PrintOrders(string searchString, string searchOrder)
        { 
            var user = from m in db.OrderDetails   
                       select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.Order.ClientID.Contains(searchString));               
            }
            int tmp = Int32.Parse(searchOrder);
            if (tmp != 0)
            {
                user = user.Where(c => c.Order.OrderId == tmp);
            }
            return this.ViewPdf("Order", "PrintView", user);
        }
