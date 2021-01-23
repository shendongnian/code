    public class Contact : Person
    {
        private ContactInfo info;
        public ContactInfo _contactInfo { get; set; }
    
        public Contact(ContactInfo _info)
        {
            if (_info == null)
                throw new ArgumentNullException("_info");
            info = _info;
        }
        public Contact(ContactInfoLoader loader)
            : this(loader.GatherContactInfo())
        {
        }
    }
