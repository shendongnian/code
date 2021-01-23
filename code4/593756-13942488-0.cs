    class Program
    {
        class ContactType
        {
            public string Name { get; set; }
        }
        class Contact
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ContactType ContactType { get; set; }
        }
        static void Main(string[] args)
        {
            CSList<Contact> contacts = new CSList<Contact>();
            //add contacts to the list
            var x = from c in contacts
                    select new {
                        c.Id,
                        c.Name
                        ContactTypeName=c.ContactType.Name
                    };
        }
    }
