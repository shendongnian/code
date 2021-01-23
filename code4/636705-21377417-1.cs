    public class YourClass {		
      public int Status = 0;
      public String ID = "";
    }
    using CodeBetter.Json;
    YourClass object = Converter.Deserialize<YourClass >(jsonString);
