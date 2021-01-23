    int? lid = ...
    if (lid.HasValue())
    {
        var results = context.NewsItems
            .Where(n => n.LibraryID == lid).ToList();
    }
