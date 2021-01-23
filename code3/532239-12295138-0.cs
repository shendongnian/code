    List<string> uniqueItems = tagarray
        .Distinct()
        .Where(x => !db.Tags.Contains(x))
        .ToList();
    
    foreach (string uniqueItem in uniqueItems)
    {
        var tag = new Tag
        {
            Tag1 = tagval
        };
        db.AddToTags(tag);   
    }
    db.SaveChanges();
