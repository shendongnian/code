    public class LegacyObject
    {
        public virtual vwContact Contact { get; set; }
        public string ContactId { get; set; } //references vwContact.LegacyKeyField
    }
    public class LegacyObjectExtensions
    {
        public static vwContact Contacts(this LegacyObject legacyObject)
        {
            var dbContext = new LegacyDbContext();
            var contacts = from o in legacyObject
                           join c in dbContext.vwContact
                               on o.ContactId == c.LegacyKeyField
                           select c;
            return contacts;
        }
    }
