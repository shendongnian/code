    var people = new List<Person>();
    using (var stream = File.OpenRead("Input.txt"))
    {
        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                int id = int.Parse(reader.ReadLine().Substring(3));
                string firstName = reader.ReadLine().Substring(10);
                string lastName = reader.ReadLine().Substring(9);
                var newPerson = new Person()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName
                };
                people.Add(newPerson);
            }
        }
    }
