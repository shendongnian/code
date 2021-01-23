    public class SomeObject
    {
        public virtual vwContact Contact { get; set; }
        public int ContactId { get; set; } //references vwContact.KeyField
    }
    public class SomeObjectExtensions
    {
        public static vwContact Contacts(this SomeObject someObject)
        {
            var dbContext = new LegacyDbContext();
            var contacts = from o in someObject
                           join c in dbContext.vwContact
                               on o.ContactId == c.KeyField
                           select c;
            return contacts;
        }
    }
