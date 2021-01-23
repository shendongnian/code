    var query= from p in people
               join d in departments on p.Department equals d.ID
               group d by new { p.ID, p.Surname, p.Title } into g
               select new {
                   g.Key.ID,
                   g.Key.Surname,
                   g.Key.Title,
                   Departments = String.Join(", ", g.Select(d => d.Name))
               };
    
