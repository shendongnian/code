    var cvr = ServiceLocator.Current.GetInstance<IContentVersionRepository>();
    IEnumerable<ContentVersion> lastTwoVersions = cvr
      .List(page.ContentLink)
      .Where(p => p.Status == VersionStatus.PreviouslyPublished || p.Status == VersionStatus.Published)
      .OrderByDescending(p => p.Saved)
      .Take(2);
    
    if (lastTwoVersions.Count() == 2) 
    {
       // lastTwoVersions now contains the two latest version for comparison
       // Or the latter one vs the e.Content object.
    }
