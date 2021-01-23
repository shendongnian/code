    public class MyClass
    {
        public static int activeCount = 0;
        public MyClass()
        {
            activeCount++;
        }
        ~MyClass()
        {
            activeCount--;
        }
    }
    //In the main
     MyClass testClass1 = new MyClass();
     MyClass testClass2 = new MyClass();
     Console.WriteLine(MyClass.activeCount);
