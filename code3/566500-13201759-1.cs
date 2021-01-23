    public class PaymentUser
    {
       private IPayment _payment;
    
       public PaymentUser(//args)
       {
          //Which payment to be used would be based on args. Using a factory here is common
          _payment = new CreditPayment(//args);
       }
    }
