    // Works in C# 3+
    foreach (string term in terms)
    {
        string copy = term;
        query2 = query2.Where(s =>
            s.Employee.FirstName.Contains(copy) ||
            s.Employee.LastName.Contains(copy) ||
            s.Employee.Username.Contains(copy));
    }
