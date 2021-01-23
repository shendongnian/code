    public class OrderInfo 
    {
      /* For Common - Protected members are accessible to subclasses! */
      protected string OrderNo {get; set;}
      protected string CustomerNo { get; set;}
      protected decimal Amount {get; set;}
    }
    
    public class CreditCardPaymentInfo : OrderInfo
    {
      /* For Credit Card */
      string CCNum {get; set;}
      string ExpDate { get; set;}
    }
    
    public class GooglePaymentInfo : OrderInfo
    {
      /* For Google */
      string GoogleOrderID {get; set;}
      ...
    }
    
    public class PaypalPaymentInfo : OrderInfo
    {
      /* For Paypal */
      ...
    }
