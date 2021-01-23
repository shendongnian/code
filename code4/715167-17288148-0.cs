    public class Person
    {
         protected Address Address {get;set;}
    }
    
    public class Instructor : Person
    {
         public void Instructor (int i, String f, String l, Address add, Schedule sc, String o, String e)
         {
            Address = add;
         }
    }
