    for (int i = 0; i < terms.Length; ++i)
    {
        int copy = i;
        query2 = query2.Where(s =>
            s.Employee.FirstName.Contains(terms[copy]) ||
            s.Employee.LastName.Contains(terms[copy]) ||
            s.Employee.Username.Contains(terms[copy]));
    }
