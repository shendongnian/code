    List<string> links = new List<string>() { link1, link2, link3};
    
    ConcurrentDictionary<string, string> summariesByLink = new ConcurrentDictionary<string, string>();
    
    Parallel.ForEach(links, link => {
    
      if (!string.IsNullOrEmpty(link))
      {
        string[] link_ar = link.Split(sep, StringSplitOptions.None);
        string page = link_ar[1];
        string filter = link_ar[2];
        string code = link_ar[3];
        string summary = MyMethod( page, filter, code);
    
        summariesByLink.Add(link, summary);
      }
    }
