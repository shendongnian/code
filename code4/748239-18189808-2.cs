         if (itemRemove != -1)
         {
             var deleteDetails = DBContext.ProductCustomizationMasters.Single(p => p.ProductID == this.ProductID && p.CustomCategoryID == catId && p.CustomType == (short)catTypeId);
            //Obviously, this isn't going to work directly, you need to actually assign the ID, Primary Key Field here...
            var deleteMe = new ProductCustomizationMasters() { PrimaryKey = deleteDetails.PrimaryKey };
            DBContext.Attach(deleteMe);
            DBContext.DeleteOnSubmit(deleteMe);
            DBContext.SubmitChanges();
            RemoveCategoryItems(catId, catTypeId);
          }
