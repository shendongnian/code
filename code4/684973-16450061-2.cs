    public class Contact : Person
    {
        //auto-generates a private field for you
        public ContactInfo Info { get; private set; }
    
        public Contact(ContactInfo info)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            this.Info = info;
        }
        public Contact(ContactInfoLoader loader)
            : this(loader.GatherContactInfo())
        {
        }
    }
