    IEnumerable<FileInfo> lastFiles = 
        dir.EnumerateFiles()
           .Select(f => new {
                File = f,
                Name = f.Name.Split('_')[0],
                Date = DateTime.ParseExact(f.Name.Split('_', '.')[1], "yyyyMMdd", CultureInfo.InvariantCulture)
           })
           .GroupBy(x => x.Name)
           .Select(g => g.OrderByDescending(x => x.Date).First().File);
