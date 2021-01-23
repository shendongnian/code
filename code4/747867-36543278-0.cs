    class Person
    {
        public string Name;
        public string Phone;
        public Person(string n, string p)
        {
            Name = n;
            Phone = p;
        }
    }
    static void TestDynamicLinq()
    {
        foreach (var x in new Person[] { new Person("Joe", "123") }.AsQueryable().Select("string.Format(\"{0} - {1}\", it.Name, it.Phone)"))
            Console.WriteLine(x);
    }
