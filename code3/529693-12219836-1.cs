    class Name
    {
        public string FirstName { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<Name>() { new Name() { FirstName = "Albert"}, 
                                            new Name() { FirstName = "Bob"}};
    
            var values = from n in names
                         select new
                         {
                             FirstVal = null as object,
                             SecondVal = n.FirstName,
                             ThirdVal = null as object
                         };
       }
    }
