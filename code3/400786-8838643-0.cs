    public IEnumerable<Person> Find(Func<Person, bool> predicate)
    {
      foreach(Person p in family.Person)
      {
        IEnumerable<Person> result = FindFromPerson(p);
        foreach(Person x in result)
        {
          yield return x;
        }
      }
    }
    public IEnumerable<Person> FindFromPerson(Person p, Func<Person, bool> predicate)
    {
      if predicate(p)
      {
        yield return p;
      }
      foreach(Person child in p.People)
      {
        IEnumerable<Person> childResults = FindFromPerson(child);
        foreach(Person x in childResults)
        {
          yield return x;
        }
      }
    }
