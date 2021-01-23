    public  IEnumerable<KeyValuePair<string, Int32>> YourQuery(DateTime date, string code)
    {
       
               var result = 
               from c in customers
               where c.Field<string>("Region") == code
               
               from o in orders
               where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                   && (DateTime)o["OrderDate"] >= date
               
               select new 
               { 
                  CustomerID = c.Field<string>("CustomerID"), 
                  OrderID = o.Field<int>("OrderID") 
               };
               return result;
    }
