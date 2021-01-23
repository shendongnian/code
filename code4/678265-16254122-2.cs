    // Given that 'Person' for the sake of this example is:
    public class Person
    {
        public string FirstName;
        public string LastName;
    }
    // And you have a dictionary sorted by Person.FirstName:
    var dict = new SortedDictionary<string, Person>();
    // ...initialise dict...
    // Make list reference a List<Person> ordered by the person's LastName
    var list = (from entry in dict
                orderby entry.Value.LastName
                select entry.Value).ToList();
    // Use list to populate the listbox
