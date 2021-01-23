    public class ContactProvider
    {
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }
        public Contact LoadContact(int contactId)
        {
            ...
        }
    }
    public class Contact
    {
        public string CorporateName { get; set; }
        public string Logo { get; set; }
        // No need for provider properies, or possibly one of type ContactProvider
    }
