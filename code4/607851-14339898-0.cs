    public class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }
    var people = new List<Person>(); //Fill it
    var sorted = people.OrderBy(p => p.Name).ThenBy(p => p.Age);
