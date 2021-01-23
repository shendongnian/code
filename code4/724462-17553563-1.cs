    IEnumerable<Person> people = List; // Start with no filters
    // Add filters - just chaining as needed
    if (!string.IsNullOrWhitespace(name) && !string.IsNullOrWhitespace(lastname))
    {
        people = people.Where(s => s.Name == name && s.Surname == lastname);
        if (!string.IsNullOrWhitespace(phone))
            people = people.Where(s => s.Phone == phone);
    }
    //... Add as many as you want
    List<Person> newList = people.ToList(); // Evaluate at the end
