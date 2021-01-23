    class NameAndAge
    {
        public String Name;
        public Int32 Age;
    }
    class Whatever
    {
        public IEnumerable<NameAndAge> GetNameAndAges(IEnumerable<dynamic> enumerable)
        {
             return from b in enumerable select new NameAndAge { Name = b.name,
                                                                 Age = b.age};
        } 
    }
