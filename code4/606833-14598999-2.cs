    public class Dummy{
      public bool IsCondition {get; set;}
      
      [ConditionallyRequired("IsCondition", true)]
      public string SometimesRequired {get; set;}
    }
