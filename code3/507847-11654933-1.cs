    public class CustomerViewModel
    {
      public int ID { set;get;}
      public string Name { set;get;}
      public Address Address {set;get;}
      public IList<Order> Orders {set;get;}
      public CustomerViewModel()
      {
         if(Address==null)
             Address=new Address();
         if(Orders ==null)
             Orders =new List<Order>();
      }
    }
    public class Address 
    {
      public string AddressLine1 { set;get;} 
      //Other properties 
    }
    public class Order
    {
      public int OrderID{ set;get;} 
      public int ItemID { set;get;}
      //Other properties 
    }
