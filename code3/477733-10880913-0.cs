    public class Contact
    {
      public string firstName { get; set; }
      public string lastName { get; set; }
      public int age { get; set; }
      public address address { get; set; };
      public List<phoneNumber> phoneNumber { get; set; }
    }
    public class address
    {
         public string streetAddress { get; set; }
         public string city { get; set; }
         public string state { get; set; }
         public string postalCode { get; set; }
    }
    public class phoneNumber
    {
         public string type { get; set; }  
         public string number { get; set; }
    }
    var contact = Newtonsoft.Json.JsonConvert.DeserializeObject<Contact>(data);
    var count = contact.phonenumber.Count;
