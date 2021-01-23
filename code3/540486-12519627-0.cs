    public class Person {
      public string Name { get; set; }
      public int Age { get; set; }
      public string Address { get; set; }
      public double Height { get; set; }
      public bool IsTest { get; set; }
      public double GroupProperty { get { return IsTest ? 0.0 : Height } }
    }
    var groupedPersons = persons.GroupBy(person =>
      new {
            person.Name,
            person.Age,
            person.Address,
            person.GroupByProperty
      }).ToList();
