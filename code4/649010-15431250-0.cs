    public class ValidationAttribute : Attribute{
      public type RuleType{get;set;}
      public string Rule{get;set;}
      public string[] RuleValue{get;set;}
    }
