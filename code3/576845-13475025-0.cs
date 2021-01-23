    IEnumerable<PropertyInfo> properties = typeof(Person)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => fields.Contains(p.Name));
    foreach (Person person in persons)
    {
        foreach (PropertyInfo prop in properties)
            Console.WriteLine("{0}: {1}", prop.Name, prop.GetValue(person, null));
    }
