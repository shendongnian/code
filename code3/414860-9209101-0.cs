    using (var context = new EntityBazaCRM(Settings.sqlDataConnectionDetailsCRM))
    {
        Settings.WybraneSzkolenie = context.Szkolenies
           .Where(d => d.SzkolenieID == szkolenieId)
           .Select(d => SqlFunctions.DataLength(d.DataField))
           .FirstOrDefault();
    }
