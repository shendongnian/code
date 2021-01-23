    public abstract class Choice
    {
        public abstract string Discount { get; }
        public abstract string Type { get; }
        public string Buy()
        {
           return "You buy" + Type + " with " + Discount;
    }
    public class clsBike: Choice
    {
        public abstract string Discount { get { return "10% Discount Off"; } }
        public abstract string Type { get { return "Bike"; } }
    }
    public class clsCar:Choice
    {
        public abstract string Discount { get { return " $15K Less"; } }
        public abstract string Type { get { return "Car"; } }
    }
