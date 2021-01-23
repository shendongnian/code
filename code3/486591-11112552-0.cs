    public class SomeExampleModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Street { get; set; }
        public IList<Contact> Contacts { get; set; }    
    }
    public class Contact
    {
        public int Id { get; set; }
        public int SomeExampleModelId { get; set; }
        public ContactType Type { get; set; }
        public string ContactText { get { return Type.ToString(); } }
        public string ContactValue { get; set; }
    }
    public enum ContactType
    {
        email,
        Phone,
        mobile,
        fax
    }
