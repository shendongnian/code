    public class PaymentTypeX : PaymentBase
    {
        public string Name
        {
            get { return Info1; }
            set { Info1 = value; }
        }
        public int Number
        {
            get {
                int n;
                Int32.TryParse(Info2, out n);
                return n; 
            }
            set { Info2 = value.ToString(); }
        }
    }
