    namespace BoxingAndTypeConversion
    {
        class Program
        {
            public class MyClass { }
    
            static void Main(string[] args)
            {
                int num = 5;
                object obj = num;  //boxing
                //////////////////////
                MyClass my = new MyClass();
                object obj2 = my; //what is name this convert  (whethere is boxing?)
            }
        }
    }
