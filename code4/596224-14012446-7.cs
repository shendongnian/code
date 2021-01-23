    public class Order
    {
        public string ID { get; set; } // order ID
        public string UserID { get; set; } // user ID - also request param
        // ...
    }
    
    Routes.Add<Order>("/User/{UserID}/Oders");
