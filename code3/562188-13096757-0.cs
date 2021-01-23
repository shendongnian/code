    public static class Program
    {
        static void Main(string[] args)
        {
            Mother mother = new Mother {
                FirstName = "M First", LastName = "M Last", Contact = "225632655"
            };
            //Add dependents
            mother.AddChild(new Child{ChildID = 1, FirstName = "Child FirstName 1", LastName = "Child LastName 1"});
            mother.AddChild(new Child{ChildID = 2, FirstName = "Child FirstName 2", LastName = "Child LastName 2"});
            mother.AddChild(new Child{ChildID = 3, FirstName = "Child FirstName 3", LastName = "Child LastName 3"});
            Console.WriteLine(mother);
            //List all the mother dependents
            foreach(Child c in mother.Children)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }
    }
    class Mother
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Contact {get; set;}
        private List<Child> _child;
        public Mother()
        {
            _child = new List<Child>();
        }
        public void AddChild(Child child)
        {
            _child.Add(child);
        }
        public List<Child> Children
        {
            get { return _child; }
        }
        public override string ToString()
        {
 	         return string.Format("{0}, {1} ({2})", LastName, FirstName, Contact);
        }
    }
    class Child
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int ChildID {get; set;}
        public override string  ToString()
        {
 	         return string.Format("{0} {1}, {2}", ChildID, LastName, FirstName);
        }
    }
