    public class PaymentHelper
    {
      private PaymentDetails _details;
    
      public string Id { get { return _details.Id; } private set { _details.Id=value; } }
      public string Status { get { return _details.Status; } private set { _details.Status = value; } }
    }
