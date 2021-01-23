    public class Customer:ICustomerEx
    {
     void Load(DataRow row)
     {
       CustomerRegistry.theRegistry.Load(row);
     }
    }
