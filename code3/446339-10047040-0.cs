    var q = (from web in DataContext.Webs select web);
    List<int?> k1 = new List<int?>() { 1, 2 };
    List<int?> k2=new List<int?>() { 16, 17 };
    q = q.Where(web => DataContext.WebTechMaps
                                  .Any(t => t.WebsiteId == web.WebsiteId && 
                                            k1.Contains(t.TechId)));
    System.Diagnostics.Debug.WriteLine(q.Count());
    q = q.Where(web => DataContext.WebTechMaps
                                  .Any(t => t.WebsiteId == web.WebsiteId &&
                                       k2.Contains(t.TechId)));
    System.Diagnostics.Debug.WriteLine(q.Count());
