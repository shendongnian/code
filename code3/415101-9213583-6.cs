    public interface IDetails
    {
      int Id { get; } 
      string Status { get; } 
    }
    
    public class PaymentDetails : IDetails
     { 
      public int Id { get; private set; }
      public string Status { get; private set; } 
    }
    
    public class PaymentHelper
    {
      private PaymentDetails _details;
      public IDetails Details { get { return _details; } private set { _details = value; } }
    }
