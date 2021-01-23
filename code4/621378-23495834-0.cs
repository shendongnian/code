    public class Person {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public IList<PhoneNumber> PhoneNumbers { get; set; }
      public IList<EmailAddress> EmailAddresses { get; set; }
      public IList<Address> Addresses { get; set; }
    }
