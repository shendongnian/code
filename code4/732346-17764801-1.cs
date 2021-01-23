    var semenProcessViewModel = db.SemenProcesses.ToList()
       .Where(s => s.SemenProcessID == semenProcessID)
       .Select(s => new SemenProcessViewModel {
           SemenProcess = s,
           WokeTitle = string.Join("", s.CollectionMethods.Distinct().Select(c => c.Title))
       }).SingleOrDefault();
