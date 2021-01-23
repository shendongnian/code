    var userGrades = new Dictionary<string, List<decimal>>();
    string currentUserName = null;
    foreach (string line in File.ReadLines(sourcePath))
    { 
        decimal grade;
        if (decimal.TryParse(line.Trim(), out grade))
        {
            // line with a grade
            List<decimal> grades;
            userGrades.TryGetValue(currentUserName, out grades);
            if (grades != null) grades.Add(grade);
        }
        else
        {
            // line with the name
            currentUserName = line.Trim();
            if (!userGrades.ContainsKey(currentUserName))
                userGrades.Add(currentUserName, new List<decimal>());
        }
    }
    using (var writer = new StreamWriter(destPath))
    {
        foreach (var ug in userGrades)
        {
            writer.WriteLine(ug.Key);
            foreach(decimal d in ug.Value)
                writer.WriteLine(d);
            decimal roundedAverage = Math.Round(ug.Value.Average(), 2);
            writer.WriteLine(roundedAverage);
        }
    }
