       using (var con = new cpdEntities())
       {
        
       var c = new Customer()
       {
          CustomerId = Id, //If Zero is time to insert or else is time to update
          CustomerIdNo = IdNoTextBox.Text,
          CustomerName = CustomerNameTextBox.Text
       };
    
        var cus = new Customer();
        if (c.CustomerId > 0)
            cus = con.Customers.First(c => c.CustomerId == t.CustomerId);
        cus.CustomerId = c.CustomerId;
        cus.CustomerIdNo = c.CustomerIdNo;
        cus.CustomerName = c.CustomerName;
        
         if (c.CustomerId == 0)
             con.Customers.AddObject(cus);
         con.SaveChanges();
         int i = cus.CustomerId;//SCOPE_IDENTITY
        }   
 
