    private void LoadData()
    {
        _data = new Dictionary<int, Language>();
        var languages = _db.Languages.Include("Region").OrderBy(e => e.Region.Name).ThenBy(e => e.Name);
    
        foreach (Language item in languages)
        {
            _data.Add(item.Id, item);   //// ERRORS HERE ////
        }
    }
