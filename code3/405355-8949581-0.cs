     class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> dic1 = new Dictionary<int, Person>();
            dic1.Add(0, new Person { Name = "user1158781" });
            Dictionary<int, Person> dic2 = new Dictionary<int, Person>();
            foreach (var item in dic1)
            {
                dic2.Add(item.Key, (Person)item.Value.Clone());
            }
            dic1[0].Name = "gz";
            Console.WriteLine(dic1[0].Name);
            Console.WriteLine(dic2[0].Name);
        }
        class Person : ICloneable
        {
            public string Name { get; set; }
            public object Clone()
            {
                return new Person { Name = this.Name };
            }
        }
    }
