    var persons = new List<Person>();
    for (int i = 0; i < 100; i++)
    {
          persons.Add(new Person { 
                    Name = String.Format("John {0}", i), 
                    Surname = String.Format("Smith {0}", i), 
                    Age = i });
    }
