    // Only works in C# 5
    foreach (string term in terms)
    {
        query2 = query2.Where(s =>
            s.Employee.FirstName.Contains(term) ||
            s.Employee.LastName.Contains(term) ||
            s.Employee.Username.Contains(term));
    }
