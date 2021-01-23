    public partial class MyProg: Form
    {
        public static void method1(string text)
        {
           string letter = method2("some text");
           // Here i want to use the value from string letter from method2.
        }
        public static string method2(string text)
        {
           string letter = "A";  //Its not A its based on another method.
           return letter;
        }      
    }
