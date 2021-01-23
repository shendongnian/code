         public bool Validate()
         {
        //Granular Customer Code and Name
        return true;
         }
    
         public bool CreateDBObject()
         {
        //DB Connection Code
        return true;
         }
      
    
    class Program
    {
       static void main(String[] args)
       {
         CustomerComponent.Customer obj = new CustomerComponent.Customer;
    
         obj.CustomerCode = "s001";
         obj.CustomerName = "Mac";
    
         obj.Validate();
         obj.CreateDBObject();
    
         obj.ADD();
        }
    }
