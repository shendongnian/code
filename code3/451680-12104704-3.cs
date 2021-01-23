    public class EntryItemView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MainContactFirstName { get; set; } 
    }
    [DataObject]
    public class EntryItemViewDataObject {
       [DataObjectMethod(DataObjectMethodType.Select)]
       public EntryItemView GetItem(...) {
           // TODO: read from the database, convert to DTO
       }
       [DataObjectMethod(DataObjectMethodType.Update)]
       public void Update( EntryItemView entry) {
          EntryItem domainObject = getById(entry.Id);
          // TODO: use EmitMapper or AutoMapper
          domainObject.MainContact.FirstName = entry.MainContactFirstName;
          // TODO: save
       }
    }
