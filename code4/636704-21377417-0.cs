    public class YourClass {		
      public String Status = "";
      public String ID = "";
    }
    using CodeBetter.Json;
    YourClass object = Converter.Deserialize<YourClass >(jsonString);
