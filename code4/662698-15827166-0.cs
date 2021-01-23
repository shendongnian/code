    Site site = null;
    foreach (var s in serverManager.Sites)
    {
        if (s.Id == 3)
        {
            site = s;
            break;
        }
    }
    if (site == null)
    {
        throw new InvalidOperationException("Sequence contains no elements that match the criteria (Site Id = 3)");
    }
    // at this stage you could use the site variable.
