     using (SomeDataContext context = new SomeDataContext())
        {
        var data = context.Data_Cust_Log.Where(x => x.CustomerID == 12) Select(x => x).FirstOrDefault();
        Data_Cust_Object = new Data_Cust_Object {CustomerID = data.CustomerID, Price = data.Price}; //and so on 
        context.Data_Cust.InsertOnSubmit(Data_Cust_Object);
        context.SubmitChanges();
        }
    
