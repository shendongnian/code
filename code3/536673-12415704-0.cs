    class Program
    {
        static void Main()
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(2);
            bytes.Add(1);
            List<float> floats = new List<float>();
            floats.Add(2.5F);
            floats.Add(1F);
            Console.WriteLine(DoStuff(bytes));
            Console.WriteLine(DoStuff(floats));
            Console.ReadLine();
        }
        static dynamic DoStuff(IList items)
        {
            dynamic item0 = items[0];
            dynamic item1 = items[1];
            return item0 - item1;
        }
    }
