         if (itemRemove != -1)
         {
             var deleteDetails = DBContext.ProductCustomizationMasters.Single(p => p.ProductID == this.ProductID && p.CustomCategoryID == catId && p.CustomType == (short)catTypeId);
            //Don't do this.
            //DBContext.ProductCustomizationMasters.Attach(deleteDetails);
            DBContext.ProductCustomizationMasters.DeleteOnSubmit(deleteDetails);
            RemoveCategoryItems(catId, catTypeId);
          }
