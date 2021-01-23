    class Person
    {
        public string Name { get; set; } 
        public int? Age { get; set; } 
        public string Role { get; set; } 
    }
    Person person = new Person() { Name = "John", Age = 21, Role = "Employee" };
    Person updatePerson = new Person() { Role = "Manager" };
    person = MapValidValues(updatePerson, person);
