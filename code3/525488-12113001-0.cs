    public class Customer : IEnumerable<string>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public List<CreditCard> CreditCards {get; set;}
        public List<Address> Addresses{get; set;}
    
        public IEnumerator<string> GetEnumerator()
        {
            yield return FirstName;
            yield return LastName;
            foreach (CreditCard c in CreditCards)
            {
                yield return c.ToString();
            }
            foreach (Address a in Addresses)
            {
                yield return a.ToString();
            }
        }
    }
    ...
    var result = allCustomers.SelectMany(c => c);
