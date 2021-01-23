    //version using overridden GetHashCode and Equals methods as per @lazyberezovsky's comments 
    public class CreditCard
    {
        long creditCardNumberClean; //given the card number is numeric this is the most efficient way of storing it
        string creditCardNumberOriginal;
        public string CreditCardNumber
        {
            get
            {
                return this.creditCardNumberOriginal;
            }
            set
            {
                this.creditCardNumberOriginal = value;
                this.creditCardNumberClean = long.Parse(value.Replace(" ", "")); 
            }
        }
        public CreditCard(string creditCardNumber)
        {
            this.CreditCardNumber = creditCardNumber;
        }
        public override bool Equals(object obj)
        {
            CreditCard other = obj as CreditCard;
            return 
                other == null 
                ? false 
                : this.creditCardNumberClean.Equals(other.creditCardNumberClean);
        }
        public override int GetHashCode()
        {
            return this.creditCardNumberClean.GetHashCode();
        }
    }
