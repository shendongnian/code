    public class Test
    {
        // no actual implementation of myProperty is required in this form
        public int[,] myProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.myProperty = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine(t.myProperty[1, 2]);
            t.myProperty[1, 2] = 0;
            Console.WriteLine(t.myProperty[1, 2]);
        }
    }
