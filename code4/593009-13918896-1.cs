        class Program
    {
        static void Main(string[] args)
        {
            int[] i = {1, 2, 3, 4, 5};
            i.ToList().ForEach(x => Console.WriteLine(x));
            Wrapper<int> w = new Wrapper<int>(i);
            w.Index = 2;
            w.Item = 5;
            
            
            i.ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
    }
