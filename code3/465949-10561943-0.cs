        using (BaseModelDataContext context = new BaseModelDataContext())
        {
            context.Connection.Open();
            
            OR
            
            context.Database.Connection.Open(); 
            
            // your code here
