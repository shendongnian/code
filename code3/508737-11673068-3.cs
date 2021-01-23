    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int> { 1, 2, 3 };
            a.SetLast(4);
            int last = a.GetLast(); //int last is now 4
            Console.WriteLine(a[2]); //prints 4
        }
    }
