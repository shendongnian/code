    public class Human
    {
        public Human()
        {
        }
        public Human(IEnumerable<ContactNumber> contactNumbers)
        {
            if (contactNumbers == null)
            {
                throw new ArgumentNullException("contactNumbers");
            }
            
            _contactNumbers.AddRange(contactNumbers);
        }
        public IEnumerable<ContactNumber> ContactNumbers
        {
            get { return _contactNumbers; }
        }
    
        private readonly List<ContactNumber> _contactNumbers = new List<ContactNumber>();
    }
