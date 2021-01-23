    if(CustomeSettings == null) CustomerSettings = 
                                        new Collection<ProductCustomization>();
    var cat = CustomSettings.FirstOrDefault(r=>r.CategoryId == catID && 
                                               r.CustomizationType == catType);
    if(cat!=null)
    { 
         cat.DefaultFreeCount = freeCount;
         cat.ProductID = this.ProductID;
    }
    else
    {
         this.CustomSettings.Add(new ProductCustomization()
            {
                CategoryID = catId,
                CustomizationType = catType,
                DefaultFreeCount = freeCount,
                ProductID = this.ProductID
            });
     }
