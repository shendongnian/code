    var result = Enumerable
        .Range(0, lstTeachers.Count)
        .GroupBy(i => lstTeachers[i])
        .ToDictionary(g => g.Key, g => g
            .GroupBy(i => lstStudentsSex[i])
            .ToDictionary(h => h.Key, h => h
                .Select(i => lstStudentName[i])
                .ToList()));
    // result is Dictionary<string, Dictionary<string, List<string>>>
