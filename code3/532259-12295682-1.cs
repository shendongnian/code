    List<Person> list= new List<Person>();
    // ...
    var lookup = list.ToLookup(person => person.Key, person => new {Age=person.Age, Color=person.Color});
    IEnumerable<Person> peopleWithKeyX = lookup["X"];
    public class Person
    {
        public string Key { get; set; }
        public string Age { get; set; }
        public string Color { get; set; }
    }
