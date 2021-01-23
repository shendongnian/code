    var regions = (
        new[] { new { Id = "-1", Name = "---", Pattern = (string)null } }
      ).Union(
        from x in db.Userlists where x.ListType == 2 select new { Id = x.UserlistID.ToString(), Name = x.Name, Pattern = (string)null }
      ).Union(
        from x in db.Lookups where x.Category == "Stock" select new { Id = x.Key, Name = x.Key, Pattern = x.Value }
      ).ToArray();
