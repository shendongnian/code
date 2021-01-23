    public class Contact
    {
       public static List<Contact> Library = new List<Contact>();
    
       public List<Contact> Contacts = new List<Contact>();
       protected string Name;
    
       public contact ( string Name )
       {
          this.Name = Name;
          Library.Add ( this );
       }
    
    }
    
    
