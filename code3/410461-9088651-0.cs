    public class Human
    {
        public IEnumerable<ContactNumber> ContactNumbers
        {
            get { return _contactNumbers; }
        }
    
        public Human(IEnumerable<ContactNumber> contactNumbers)
        {
            if (contactNumbers == null)
            {
                throw new ArgumentNullException("contactNumbers");
            }
            
            _contactNumbers.AddRange(contactNumbers);
        }
        private readonly List<ContactNumber> _contactNumbers = new List<ContactNumber>();
    }
