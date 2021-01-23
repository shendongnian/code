        static void Main()
        {
            MyFilter f = new MyFilter(new Program(), addressof(Program.IsOdd));
            Console.WriteLine(f.Invoke(5));
        }
