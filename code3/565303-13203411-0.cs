    Item rootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
    List<Item> modifiedItemList = rootItem.Axes.GetDescendants().
           Where(item => item.Statistics.Updated >= installDateTime 
                 || item.Statistics.Created >= installDateTime).ToList();
    // add te items in the list to the publishing queue
