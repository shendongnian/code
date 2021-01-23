            var orderlist = (from a in db.Order_Master
                             join b in db.UserAccounts on a.User_Id equals b.Id into abc
                             from b in abc.DefaultIfEmpty()
                             select new
                             {
                                 Order_Id = a.Order_Id,
                                 User_Name = b.FirstName,
                                 Order_Date = a.Order_Date,
                                 Tot_Qty = a.Tot_Qty,
                                 Tot_Price = a.Tot_Price,     
                                 Order_Status = a.Order_Status,
                                 Payment_Mode = a.Payment_Mode,
                                 Address_Id = a.Address_Id 
                             });
            List<MasterOrder> ob = new List<MasterOrder>();
            foreach (var item in orderlist)
            {
                MasterOrder clr = new MasterOrder();
                clr.Order_Id = item.Order_Id;
                clr.User_Name = item.User_Name;
                clr.Order_Date = item.Order_Date;
                clr.Tot_Qty = item.Tot_Qty;
                clr.Tot_Price = item.Tot_Price;
                clr.Order_Status = item.Order_Status;       
                clr.Payment_Mode = item.Payment_Mode;
                clr.Address_Id = item.Address_Id;              
                ob.Add(clr);
            }
            using(ecom_storeEntities en=new ecom_storeEntities())
            {
                var Masterlist = en.Order_Master.OrderByDescending(a => a.Order_Id).ToList();
                foreach (var i in ob)
                {
                    var Child = en.Order_Child.Where(a => a.Order_Id==i.Order_Id).ToList();
                    obj.Add(new OrderMasterChild 
                    {
                        Master = i,
                        Childs = Child
                    });
                }        
            }
