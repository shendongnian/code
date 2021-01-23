    possibleListings.Sort(delegate(DynamicNode x, DynamicNode y)
    {
      dynamic xNode = @Model.NodeById(x.Id);
      dynamic yNode = @Model.NodeById(y.Id);
     
      dynamic xListingLevel = @Model.NodeById(xNode.ListingType);
      dynamic yListingLevel = @Model.NodeById(yNode.ListingType);
     
      int xSort = xListingLevel.SortOrder;
      int ySort = yListingLevel.SortOrder;
      return xSort.CompareTo(ySort);
    });
