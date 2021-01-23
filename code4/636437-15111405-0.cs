    List<Item> p = new List<Item>();
    var x = p.Select(c => new Item
         {
             AssetID = c.AssetID,
             LastModifiedDate = c.LastModifiedDate.Date
         }).OrderBy(y => y.id).ThenByDescending(c => c.LastModifiedDate).Distinct();
