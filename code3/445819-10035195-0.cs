    return activeSemester.Select(c => new ActiveSemester
    {
        id = c.SemesterId,
        name = c.Name == "Summer" ? GetSummmer(c.StartDate, c.EndDate) : c.Name
    }).ToList();
----------
    private string GetSummer(DateTime startDate, DateTime endDate)
    {
        if (startDate == summer1Start || endDate == summer1End)
            return "Summer I";
        if (startDate == summer2Start || endDate == summer2End)
            return "Summer II";
        if (startDate == summer3Start || endDate == summer3End)
            return "Summer III";
        return "Unknown Summer";
    }
    private string GetSummer(Integer semesterId)
    {
        if (semesterId == summer1Id)
            return "Summer I";
        if (semesterId == summer2Id)
            return "Summer II";
        if (semesterId == summer3Id)
            return "Summer III";
        return "Unknown Summer";
    }
