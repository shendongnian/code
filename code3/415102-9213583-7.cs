    public struct PaymentDetails
    {
      public int Id { get; set; }
      public string Status { get; set; } 
    }
    
    public class PaymentHelper
    {
      public PaymentDetails Details { get; set; } 
    }
