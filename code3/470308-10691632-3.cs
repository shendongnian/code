    public class Person 
    {
         public string SayHello()
         {
             return "Hello"; 
         }
    }
    public class LoudMouth : Person
    {
        public override string SayHello()
        {
            return base.SayHello() + "!!!!";
        }
    }
    public class SadPerson : Person
    {
        public override string SayHello()
        {
            return base.SayHello() + " I am sad";
        }
    }
