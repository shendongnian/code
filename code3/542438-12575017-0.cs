    var groupByQuery =  (from c in db.Customers
                         join o in db.Orders on c.CustomerID equals o.CustomerID into lf1
                         select new
                         {
                             CustomerID = c.Id,
                             Count = lf1.Count()
                         }
                         ).OrderBy(x => x.Count);
