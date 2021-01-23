    void OldestAndYoungest(IEnumerable<Person> people, out Person youngest, out Person oldest)
    {
        youngest = null;
        oldest = null;
        foreach (var person in people)
        {
            if (youngest == null || person.Age < youngest.Age)
                youngest = person;
            if (oldest == null || oldest.Age < person.Age)
                oldest = person;
        }
    }
