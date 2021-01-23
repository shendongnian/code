    subCatName = subCatName.Trim();
    List<int> productIDs = ProductSubCat
         .Where(x => StringComparer.OrdinalIgnoreCase.Equals(x.SubCategory.SubCategoryName.Trim(), subCatName))
         .Select(p => p.ProductID)
         .ToList();
