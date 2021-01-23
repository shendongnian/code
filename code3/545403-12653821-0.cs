    public class Foo
    {
        public string Name { get; set; }
        public uint Val1 { get; set; }
        public uint Val2 { get; set; }
        public ushort Val3 { get; set; }
    }
        static void Main(string[] args)
        {
            OrderFoos();
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
        private static void OrderFoos()
        {
            List<Foo> list = new List<Foo>();
            list.Add(new Foo() { Name = "2nd", Val1 = 2, Val2 = 1, Val3 = 1 });
            list.Add(new Foo() { Name = "1st", Val1 = 1, Val2 = 1, Val3 = 1 });
            list.Add(new Foo() { Name = "3rd", Val1 = 1, Val2 = 2, Val3 = 1 });
            list.Add(new Foo() { Name = "4th", Val1 = 2, Val2 = 1, Val3 = 2 });
            list.Add(new Foo() { Name = "6th", Val1 = 4, Val2 = 1, Val3 = 3 });
            list.Add(new Foo() { Name = "5th", Val1 = 3, Val2 = 1, Val3 = 3 });            
            list = list.OrderBy(x => x.Val3).ThenBy(x => x.Val2).ThenBy(x => x.Val1).ToList();
            list.ForEach(x => Console.WriteLine(x.Name));
        }
