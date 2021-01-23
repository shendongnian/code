    using System.Web.Script.Serialization;
    public class TestAttribute
    {
      [ScriptIgnore]
      public string SomeProperty1 { get; set; }
    
      public string SomeProperty2 { get; set; }
    
      public string SomeProperty3 { get; set; }
    
      [ScriptIgnore]
      public string SomeProperty4 { get; set; }
    }
