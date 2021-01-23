    public class MyCustomerInfo
    {
      public List<CustomObject> CustomerList { set;get;}
      public string ErrorDetails { set;get;}
    
      public MyCustomerInfo()
      {
        if(CustomerList==null)
           CustomerList=new List<CustomObject>();  
      }
    }
