     using (DataClasses1DataContext context = new DataClasses1DataContext())
        {
        var data = context.Data_Cust_Log.Where(x => x.CustomerID == 12) Select(x => x).FirstOrDefault();
        context.Data_Cust.InsertOnSubmit(data);
        context.SubmitChanges();
        }
    
