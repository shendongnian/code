    public class Money 
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public Money CloneRounding() {
           var obj = (Money)this.MemberwiseClone();
           obj.Amount = Math.Round(obj.Amount, 2);
           return obj;
        }
    }
    var roundMoney = money.CloneRounding();
