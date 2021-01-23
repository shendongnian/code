    var searchResults = searcher.FindAll();
    foreach (Principal p in searchResults)
    {
      if(p.SamAccountName == User.Identity.Name)
      {
          //your in!
      }
    }
