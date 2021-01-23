    public class BaseOrders
    {
        public string invoiceID { get; set; }
        public string employee { get; set; }
        public string store { get; set; }
        public string client { get; set; }
        public string invoiceDate { get; set; }
        public string total { get; set; }
    
    
      public static List<BaseOrders> getOrders()
      {
          //your implementation
      }
    }
