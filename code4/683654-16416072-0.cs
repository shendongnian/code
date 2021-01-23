    public MagentoService.catalogCategoryTree catalogCategoryTree(string parentId, string storeView)
    {
      parentId = (string.IsNullOrEmpty(parentId)) ? null : parentId;
      storeView = (string.IsNullOrEmpty(storeView)) ? null : storeView;
      return base.catalogCategoryTree(sessionId, parentId, storeView);
    }
