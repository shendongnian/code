    public class MyClass
    {
        public static int activeCount = 0;
        public MyClass() => activeCount++;
        ~MyClass() => activeCount--;
    }
    //In the main
    var testClass1 = new MyClass();
    var testClass2 = new MyClass();
    Console.WriteLine(MyClass.activeCount);
