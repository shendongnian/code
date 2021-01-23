    public static void DeleteCategory(int id)
    {
        var result = from a in adb.Artifacts
                     where a.CatgId == id
                     group a by a.ArtId into g
                     select new { count = g.Count(), artid = g.Key }; //not able to get ArtId using range variable a.
        
        if (result.count > 0)
        {
            foreach (var r in result)
            {
                MyArtifact.DeleteByKey(r.artid);
            }
        }
    }
