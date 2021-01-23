    [DataContract]
    public class Person
    {
      [DataMember(IsRequired = False)]
      public string FirstName { get; set; }
      public bool ShouldSerializeFirstName()
      {
        return !string.IsNullOrEmpty(FirstName);
      }
      ...
    }
