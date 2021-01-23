    public class MethodOfPayment
    {
        public enum enumType { Visa, Mastercard };
        public string Number { get; set; }
        public enumType Type { get; set; }
    }
    public class Receipt
    {
        public MethodOfPayment MOP { get; set; }
    }
