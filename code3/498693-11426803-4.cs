public partial class PaymentEntities //The name of your EF entities
{
   public IQueryable<IPayment> AllPayments
   {
      return this.CashPayment.Union(this.CreditCardPayment); //This is not good, but just an example. The abstract class approach would be better here.
   }
    public void InsertPayment(IPayment payment)
    {
         this.AddObject(payment.GetType().Name, payment);
    }
}
