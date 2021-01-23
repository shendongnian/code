    List<Person> persons = new List<Person>();
    persons.Add(new Person() { Name = "Joe", Surname = "Black" });
    persons.Add(new Person() { Name = "Misha", Surname = "Kozlov" });
    dataGridView1.DataSource = persons;
    // added a new item
    persons.Add(new Person() { Name = "John", Surname = "Doe" });
    // bind to the updated source
    dataGridView1.DataSource = persons;
