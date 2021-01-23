    EntityGrouper companyGrouper = new EntityGrouper()
    {
      KeySelector = o => new EntityGroupKey() {ID = o.CompanyID, Name = o.CompanyName},
      ResultSelector = key => new TreeViewItem
      {
        CompanyID = key.ID,
        DisplayName = key.Name,
        ItemTypeEnum = TreeViewItemType.Company
      }
    }
    
    EntityGrouper divisionGrouper = new EntityGrouper()
    {
      KeySelector = o => new EntityGroupKey() {ID = 0, Name = o.Division},
      ResultSelector = key => new TreeViewItem
      {
        DisplayName = key.Name,
        ItemTypeEnum = TreeViewItemType.Division
      } 
    }
    
    companyGrouper.NextGrouping = divisionGrouper;
    
    List<TreeViewItem> oneWay = companyGrouper.GetItems(source);
    
    companyGrouper.NextGrouping = null;
    divisionGrouper.NextGrouping = companyGrouper;
    
    List<TreeViewItem> otherWay = divisionGrouper.GetItems(source);
