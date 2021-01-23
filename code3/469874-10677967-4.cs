    public class MethodOfPayment
    {
        public enum enumCardType { Visa, Mastercard };
        public enum enumPaymentType { CreditCard, Cash };
        public string Number { get; set; }
        public enumPaymentType PaymentType { get; set; }
        public enumCardType CardType { get; set; }
    }
    public static class MOP
    {
        public static class CreditCard
        {
            public static MethodOfPayment Visa(string number)
            {
                get
                {
                    return new MethodOfPayment() { 
                        Number = number,
                        PaymentType = MethodOfPayment.enumPaymentType.CreditCard,
                        CardType = MethodOfPayment.enumCardType.Visa
                    };
                }
            }
        }
    }
