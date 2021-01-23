    [DataContract]
    public class Person
    {
      [DataMember(IsRequired = False, EmitDefaultValue = False)]
      public string FirstName { get; set; }
      public bool ShouldSerializeFirstName()
      {
        return !string.IsNullOrEmpty(FirstName);
      }
      ...
    }
