    class Program
    {
        enum MyEnum
        {
            Yes = 1, 
            No, 
            Maybe
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MyEnum.Maybe.ToString());
            Console.ReadLine();
        }
    }
