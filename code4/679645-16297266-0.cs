    var companyquery1 = db.MovieInformations
                         .Select(m => movieInfo.MovieTitle.FirstOrDefault())
                         .GroupBy(c => char.IsDigit(c) ? "Number" : c.ToString())
                         .Select(g => Character = g.Key, Number = g.Count())
                         .OrderBy(a => a.Character)
