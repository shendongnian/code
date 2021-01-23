    foreach (var weekGroup in groupedProjects)
    {
        int week = weekGroup.Key;
        foreach (var project in weekGroup)
        {
            Console.WriteLine("Week " + week + " | Project: " + project.ID);
        }
    }
