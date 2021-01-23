    class Program
    {
        static void Main(string[] args)
        {
    
            circle a = new circle(3);
            circle b = new circle(4);
            circle d = a;
            d.Diameter = 5;
    
            Console.WriteLine("a is {0}", a.Diameter); // shows 5
            Console.WriteLine("b is {0}", b.Diameter); // shows 4
            Console.WriteLine("d is {0}", d.Diameter); // shows 5
        }
    }
    
    class circle
    {
        public int Diameter;
        public circle(int d)
        {
            Diameter = d;
        }
    }
