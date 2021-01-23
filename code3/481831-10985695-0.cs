        class Program
    {
        static void Main(string[] args)
        {
            ClassA<int> a = new ClassA<int>();
            ClassA<double> b = new ClassA<double>();
            Console.WriteLine(a.GetCounterAndAddOne());
            Console.WriteLine(b.GetCounterAndAddOne());
            Console.Read();
        }
    }
    class BaseA
    {
        protected static int counter = 0;
    }
     class ClassA<T>:BaseA
    {
         public int GetCounterAndAddOne()
         {
             return BaseA.counter++;
         }
    }
