    var semenProcessViewModel = db.SemenProcesses
       .Where(s => s.SemenProcessID == semenProcessID).ToList()
       .Select(s => new SemenProcessViewModel {
           SemenProcess = s,
           WokeTitle = string.Join("", s.CollectionMethods.Select(c => c.Title))
       }).SingleOrDefault();
