    var query = dtx.Categories.Where(c => c.CategoryId == CatId);
    if (!string.IsNullOrEmpty(param1))
        query = query.Where(c => c.Param1 == param1);
    if (!string.IsNullOrEmpty(param2))
        query = query.Where(c => c.Param2 == param2);
