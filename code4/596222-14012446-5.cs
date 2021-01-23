    public class Order
    {
        public string ID { get; set; } // order ID
        pulbic string UserID { get; set; } // user ID - also request param
        // ...
    }
    
    Routes.Add<Order>("/User/{UserID}/Oders");
