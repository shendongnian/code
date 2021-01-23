    public class GetContactsResult
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        ...
    }
    protected static IQueryable<GetContactsResult> getContacts()
    {
        ...
        var contacts =
            (from c in context.ContactSet
             ...
             select new GetContactsResult()
             {
                 ...
             });
        return contacts;
    }
