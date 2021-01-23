    public IEnumerable<string> FilterNames(Func<string, bool> filter)
    {
        return people.Select(person => person.Name)
                     .Where(filter);
    }
