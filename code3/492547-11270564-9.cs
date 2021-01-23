    public MyCustomerInfo GetCustomerDetails()
    {
      var customerInfo=new MyCustomerInfo();
      
      // Execute a SQL command
        try
        {
          dr = SQL.Execute(sql);
       
          if(dr != null) {
             while(dr.Read()) {
               CustomObject c = new CustomObject();
               c.Key = dr[0].ToString();
               c.Value = dr[1].ToString();
               c.Meta = dr[2].ToString();
               customerInfo.CustomerList.Add(c);
             }
          }
          else
          {
              customerInfo.ErrorDetails="No records found";
          } 
       }
       catch(Exception ex)
       {
           //Log the error in this layer also if you need it.
           customerInfo.ErrorDetails=ex.Message;
       }     
      return customerInfo;    
    }
