    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            Console.WriteLine(myClass.Value);  // Displays 1
            Increment(myClass);
            Console.WriteLine(myClass.Value);  // Displays 2
            Increment(myClass);
            Console.WriteLine(myClass.Value);  // Displays 3           
            Increment(myClass);
            Console.WriteLine(myClass.Value);  // Displays 4
            Console.WriteLine("Hit Enter to exit.");
            Console.ReadLine();
        }
        public static void Increment(MyClass myClassRef)
        {
            myClassRef.Value++;
        }
    }
    public class MyClass
    {
        public int Value {get;set;}
        public MyClass()
        {
            Value = 1;
        }
    }
