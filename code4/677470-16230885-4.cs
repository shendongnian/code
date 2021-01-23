    using (var file = File.OpenRead("fileone.bin"))
    {
        foreach(var person in Serializer.DeserializeItems<Person>(
            file, PrefixStyle.Base128, Serializer.ListItemTag))
        {
            Console.WriteLine("{0}, {1}, {2}, {3}",
                person.ID, person.Name, person.Age, person.Email);
        }
    }
