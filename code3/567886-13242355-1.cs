    public class ContactVM
    {
       // properties of the ViewModel, to hold data for each Model we need to pass to the view 
       public Person Contacts {get; set;}
       public Address ContactAddresses {get;set;} 
       // Constructor
       public ContactVM()
       {
            Contacts = new Person();
            ContactAddresses = new Address();
       }
    }
