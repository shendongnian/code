    if (query == 1)
    {
        return View(listing);
    }
    else
    {
        return View(listing.Where(o => String.Equals(o.type, "Cover", 
                                       StringComparison.InvariantCulture) 
                                       && o.numPage > 5).ToList());
    }
