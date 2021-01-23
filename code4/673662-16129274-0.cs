    var collection = new EntityCollection<MamConfigurationToBrowser_V1>();
    var processedItems = itemFromDb.MamConfigurationToBrowser_V1
                                             .Select(browserEfItem =>
                                                     FillFromUi(browserEfItem,
                                                                item.MamConfigurationToBrowser_V1
                                                                .Single(browserUiItem => browserUiItem.BrowserVersionId == browserEfItem.BrowserVersionId)))
                                                                .ToList();
    foreach(var item in processedItems)
    {
        collection.Add(item);
    }
