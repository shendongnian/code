    List<string> Titles = new List<string>();
    Titles.Add("Truth and Life");
    Titles.Add("Truth & Life");
     return (from f in ActiveRecordLinq.AsQueryable<File>()
             where Titles.Contains(f.SeriesTitle)
             orderby f.SeriesTitle
             select new { Name = f.SeriesTitle, Slug = f.SeriesTitleSlug })
           .ToList().Distinct()
           .Select(u => Parse(u.Name, u.Slug))
           .OrderByDescending(u => u.Year)
           .ThenBy(u => u.Name)
           .ToList();
