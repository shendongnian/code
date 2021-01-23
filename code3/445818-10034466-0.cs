    return activeSemester.Select(c => new ActiveSemester
            {
                id = c.SemesterId,
                name = c.Name.Replace("Summer", "Summer I") // Here I want to check if it is Summer               
            }).ToList();
