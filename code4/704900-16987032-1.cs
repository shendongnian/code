    class Outside
    {
        public class Inside
        {
            public void Print()
            {
                System.Console.WriteLine("I am inside");
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Outside.Inside obj = new Outside.Inside();
            obj.Print();
        }
    }
