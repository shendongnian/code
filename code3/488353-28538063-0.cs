    public class OrderItem 
    {
    public int Id {get;set;}
    public int quantity {get;set;}
    public int Price {get;set;}
    public int TotalAmount {get {return this.quantity *this.Price};set;}
    }
