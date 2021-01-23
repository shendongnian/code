    public class Customer
    {
       public string FirstName {get;set;}
       public string LastName {get;set;}
       
       // Changes the first name.
       public void ChangeFirstName(string newName)
       {
          FirstName = newName;
          //The UI will never know that the property changed, and it won't update.
       }
    }
