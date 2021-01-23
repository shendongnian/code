    public partial class Payment {
        public int PaymentID { get; set; }
        public List<GiftPaymentComponent> PaymentComponents { get; set; }
        public DateTime PayedTime { get; set; } 
    }
