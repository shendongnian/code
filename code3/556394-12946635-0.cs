    public class Customer
    {
        // public int CustomerID { get; set; } // Database specific primary key
        public string Title { get; set; } 
        public string FirstName { get; set; } // Is the setter required to be publicly exposed? 
                                              // Or can it be private to the class?
        public string LastName { get; set; }  // FirstName and LastName can be part of a nested class 
                                              // Name, so that the access is more natural... 
                                              // Customer.Name.FirstName 
        public string Postion { get; set; }
        public Char Gender { get; set; } // Can be an enumeration
        public DateTime BecomeCustomer { get; set; }     
        public DateTime ModifiedDate { get; set; }
        public IList<Contact> Contacts { get; private set; } // The getter can be private and you can 
                                                             // expose only some methods like 
                                                             // Customer.GetContactOfType(type)
        
        public bool AddContact(Contact contact)
        {
             // ...
        }
        public bool RemoveContact(Contact contact)
        {
             // ...
        }       
    }
 
    public class Contact
    {
        public string ContactDetail { get; set; } // Can be named as Detail or something more specific
        public bool Status { get; set; } // Can be enumeration
        public ContactType Type { get; set; } // ContactType is an enumeration
        public string Notes { get; set; }
    }
