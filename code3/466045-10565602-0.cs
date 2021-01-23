    public ActionResult GetResults(string age, string ProgType, string Country)
    {
        var query = _db.Categories
            .Where(c => c.CatSchema.TypeName == "Programs");
            
        if (String.IsNullOrWhiteSpace(age) == false)
        {
            query = query
                .Where(c => c.FilterValToCatMaps.Any(fm => fm.FilterValue.Value == age));
        }
    
        if (String.IsNullOrWhiteSpace(ProgType) == false)
        {
            query = query
                .Where(c => c.FilterValToCatMaps.Any(fm => fm.FilterValue.Value == ProgType));
        }
        
        if (String.IsNullOrWhiteSpace(Country) == false)
        {
            query = query
                .Where(c => c.RootCat.Name == Country);
        }
        
        var result = query
            .Select(c => c.RootCat);
        
        return View();
    }
