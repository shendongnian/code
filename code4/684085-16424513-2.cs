    ArrayList people = GetAllPeopleFromSomewhere();
    ArrayList matches = new ArrayList();
    foreach (Person a in people)
    {
        if (a.FirstName == searchString)
        {
            matches.Add(a);
        }
    }
