public interface IPayment
{
     int Id { get; set; }
     int PaymentId { get; set; }
     //Other payment specific properties or methods
}
public partial class CashPayment : IPayment
{
    public int Id 
    {
       get { return CashPaymentId ; }
       set { CashPaymentId = value; }
    }
    //Other properties
}
public partial class CreditCardPayment : IPayment 
{
   //more code ...
}
