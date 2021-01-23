    [ModelBinder(typeof(AliasModelBinder))]
    public class Person
    {
          [BindAlias("first-name")]
          public string FirstName { get; set; }
          [BindAlias("last-name")]
          public string LastName { get; set; }
          //etc...
    }
