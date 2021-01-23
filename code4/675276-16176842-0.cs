    public enum RepeatOption
    {
        Daily,
        Weekly,
        Monthly
    }
    
    public class Task()
    {
       public int Id {get; set;}
       public int Title {get;set;}
       public RepeatOption Repeat {get;set;}
    }
