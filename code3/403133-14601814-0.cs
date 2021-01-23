    public class Order{
        public int OrderID {get; set;}
        public string Descrpition {get; set;}
        public List<OrderItem> OrderItems {get; set;}
    }
    public class OrderItem{
        public int OrderItemID {get; set;}
        public decimal Price{get; set;}
    }
