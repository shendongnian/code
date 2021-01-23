    public class Example
    {
        private IList<Company> companies;
        public Example()
        {
            Person p1 = new Person(){Name = "Lasantha"};
            Person p2 = new Person(){Name = "Red Kid"};
            Company comp = new Company();
            comp.People = new List<Person>();
            comp.People.Add(p1);
            comp.People.Add(p2);
            companies = new List<Company>();
            companies.Add(comp);
            var temp = companies.Where(p => p.People.Any(q => q.Name.Contains("Lasantha")));
        }
    }
    public class Company
    {
        public IList<Person> People
        {
            get;
            set;
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
