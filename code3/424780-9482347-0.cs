    public delegate void PaymentItemHandler(...)
    public partial class PaymentItem : UserControlBase 
    {
      public PaymentItemHandler OnHandler { get; set;}
    }
