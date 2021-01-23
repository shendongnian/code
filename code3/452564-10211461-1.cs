    public interface IPayment 
    { 
       void MakePayment(PaymentParameters p);   
    } 
    public class PaymentParameters{
        public string A { get; set; }
        public int B { get; set; }
    }
