    public interface ITalkable
    { 
         string SayHello(); 
         string SayGoodbye();
         etc...
    }
    
    public class Person : ITalkable
    { 
         public virtual string SayHello() { return "Hey, I'm a person just saying hello to you";} 
         public virtual string SayGoodbye() { return "Hey, I'm a person just saying goodbye to you";}
    } 
    
    public class PoshPerson: Person 
    { 
         public override string SayHello() { return "Hey, I'm too posh to say hello to you";}
         public string MakePersonSayHello() { return base.SayHello(); } 
    } 
