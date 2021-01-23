    return activeSemester.Select(c => new ActiveSemester
    {
        id = c.SemesterId,
        name = c.Name == "Summer" ? "Summer I" : c.Name
    }).ToList();
