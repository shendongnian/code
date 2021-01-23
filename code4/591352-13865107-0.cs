        List<Person> dt = new List<Person>();
        dt.Add(new Person() { Id = 1, Name = "MICHAEL JACKSON", Age = 50 });
        dt.Add(new Person() { Id = 2, Name = "MICHAEL JACKSON", Age = 51 });
        dt.Add(new Person() { Id = 3, Name = "JOHN LENNON", Age = 40 });
        dt.Add(new Person() { Id = 4, Name = "JOHN LENNON", Age = 41 });
        dt.Add(new Person() { Id = 5, Name = "ELVIS PRESLEY", Age = 42 });
        var duplicates = dt.GroupBy(r => r.Name).Where(gr => gr.Count() > 1).ToList();
        if (duplicates.Any())
        {
            foreach (var item in duplicates)
                Console.WriteLine(String.Format("{0} - {1}", item.Key, string.Join(",", item.Select(p => p.Age))));
        }
        else
            Console.WriteLine("No records duplicates.");
        Console.ReadLine();
