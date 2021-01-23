    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>(); 
            peopleList.Add(new Person() { Name = "xxx", Age = 23 });
            peopleList.Add(new Person() { Name = "yyy", Age = 25 });
            XElement xmlDoc = new XElement("people", from p in peopleList
                                                     select new XElement("person",
                                                                         new XElement("name", p.Name),
                                                                         new XElement("age", p.Age)));
            Console.WriteLine(xmlDoc.ToString());
            Console.ReadKey();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
