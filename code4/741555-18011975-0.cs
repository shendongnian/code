    public List<dataObject> GetAllCustomItems(CategoryType currType, int mCategoryID)
    {
        try
        {
            switch (currType)
            {
                case CategoryType.Dressing:
                    List<dataObject> lst = (from xx in this.DressingItems 
                           where xx.DressingInfo.CatID == mCategoryID 
                           select new dataObject() { 
                               ID = xx.DressingInfo.DressingID,
                               Name = xx.DressingInfo.Description, 
                               Selected = xx.IsDefault 
                           }).ToList();
                    break;
          }
    }
