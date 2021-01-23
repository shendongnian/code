     public ActionResult Index()
        {
            List<CustomerOrder_Result> obj = new List<CustomerOrder_Result>();
           var  orderlist = (from a in db.OrderMasters
                             join b in db.Customers on a.CustomerId equals b.Id
                             join c in db.CustomerAddresses on b.Id equals c.CustomerId
                             where a.Status == "Pending"
                             select new
                             {
                                 Customername = b.Customername,
                                 Phone = b.Phone,
                                 OrderId = a.OrderId,
                                 OrderDate = a.OrderDate,
                                 NoOfItems = a.NoOfItems,
                                 Order_amt = a.Order_amt,
                                 dis_amt = a.Dis_amt,
                                 net_amt = a.Net_amt,
                                 status=a.Status,  
                                 address = c.address,
                                 City = c.City,
                                 State = c.State,
                                 Pin = c.Pin
                             }) ;
           foreach (var item in orderlist)
           {
               CustomerOrder_Result clr = new CustomerOrder_Result();
               clr.Customername=item.Customername;
               clr.Phone = item.Phone;
               clr.OrderId = item.OrderId;
               clr.OrderDate = item.OrderDate;
               clr.NoOfItems = item.NoOfItems;
               clr.Order_amt = item.Order_amt;
               clr.net_amt = item.net_amt;
               clr.address = item.address;
               clr.City = item.City;
               clr.State = item.State;
               clr.Pin = item.Pin;
               clr.status = item.status;
               obj.Add(clr);
           }
