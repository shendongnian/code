    public class Demo1
    {
         //Static variable can be accessed without instantiating an instance of Demo1
         public static int Number;      //Demo1.Number
         public string Info {get;set;}
    }
    public class AnotherClass
    {
         void DoSth()
         {
             Demo1.Number ++;
         }
    }
