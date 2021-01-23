    context.Students.Select(s => new
    {
        s.StudentId,
        s.FirstName,
        s.LastName,
        Term = context.Terms.Where(t => t.StudentId == s.StudentId)
                            .Select(t => t.TermNumber)
                            .OrderByDescending(t => t)
                            .First()
    });
