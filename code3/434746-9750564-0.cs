    public class DynamicEFDelivery : Delivery 
    {
       public override Customer Customer 
       { 
         get
         {
           return // go to the DB and actually get the customer
         } 
         set
         {
           // attach the given customer to the current entity within the current context
           // afterwards set the Property value
         }
       }
    }
