    subCatName = subCatName.Trim();
    List<int> productIDs = _db.ProductSubCat
         .Where(x => String.Equals(x.SubCategory.SubCategoryName.Trim(), subCatName, StringComparison.OrdinalIgnoreCase))
         .Select(p => p.ProductID)
         .ToList();
