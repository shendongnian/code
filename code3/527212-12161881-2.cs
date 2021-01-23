    class Program
    {
        static void Main()
        {
            dynamic d = new ExpandoObject();
            d.key = "value";
            Program p = d.key;
            Console.WriteLine(p.Name);
        }
    
        public string Name { get; set; }
    
        public static implicit operator Program(string name)
        {
            return new Program
            {
                Name = name
            };
        }
    }
