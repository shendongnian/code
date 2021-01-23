        public class CreditCard: IComparable<CreditCard>
        {
            string creditCardNumberClean;
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
                    this.creditCardNumberClean = value.Replace(" ", "");
                }
            }
            public CreditCard(string creditCardNumber)
            {
                this.CreditCardNumber = creditCardNumber;
            }
            public int CompareTo(CreditCard other)
            {
                return this.creditCardNumberClean.CompareTo(other.creditCardNumberClean);
            }
        }
