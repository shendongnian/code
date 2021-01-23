    var result = context.Vacancies; // IQueryable!
    var tags = userSelectedTags.Select(t => t.TagId);
    
    foreach(int i in tags)
    {
        int j = i; // prevent modified closure.
        result = result.Where(v => v.Tags.Select(t => t.TagId).Contains(j));
    }
    result.Select(r => ....
