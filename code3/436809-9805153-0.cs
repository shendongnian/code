    public class MyClass
    {
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }
    }
    var myClass = new MyClass();
    Del handler = new Del(myClass.DelegateMethod);
