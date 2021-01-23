    public void InventoryCategoryList_Refresh()
    {
    
         var dataOptions = new DataLoadOptions();
         dataOptions.LoadWith<InventoryCategory>(ic => ic.InventoryLists);
         db.LoadOptions = dataOptions;
    
         InventoryCategoryList = db.InventoryCategories.Where(w => w.Active == true).OrderBy(o => o.Category).ThenBy(c=>c.InventoryItems);
    }
