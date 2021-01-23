    class Outside
    {
        public class Inside
        {
            private Outside _outer;
            public Inside(Outside outer)
            {
                if (outer == null)
                    throw new ArgumentNullException("outer");
                _outer = outer;
            }
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
            Outside outside = new Outside();
            Outside.Inside obj = new Outside.Inside(outside);
            obj.Print();
        }
    }
