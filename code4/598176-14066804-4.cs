    var results = Data.GroupBy(l => new { l.Crew, l.NameSurname});
        .SelectMany( (key, g) => 
                     new 
                     { 
                         Crew = Key.Crew,
                         NameSurname = Key.NameSurname,  
                         groups = g 
                     });
    var pivoted = new List<PivotedCrew>();
    
    foreach(var item in results)
    {
        pivoted.Add( 
            new PivotedCrew
            {
                Crew  = item.Crew,
                NameSurname = item.NameSurname,
                Q1 = item.groups.Where(x => x.Period == "Q1")
                         .FirstOrDefault().value,
                Q2 = item.groups.Where(x => x.Period == "Q2")
                         .FirstOrDefault().value,
                Q3 = item.groups.Where(x => x.Period == "Q3")
                         .FirstOrDefault().value
            });
    }
