        static void Main(string[] args)
        {
            var x = new object();
            if (x == null)
            { Console.WriteLine("x is null"); }
            else
            { Console.WriteLine(x.ToString()); }
            x = null;
            if (x == null)
            { Console.WriteLine("x is null"); }
            else
            { Console.WriteLine(x.ToString()); }
        }
