    public ActionResult Render()
    {
        var sluggifiedProjection =
            db.bm_product_categories
            .ToList()
            .Select(category => new CategoryViewModel
            {
                CategoryNameSlugged = category.Category_Name.GenerateSlug()
            });
    
        return PartialView("_CategoriesList", sluggifiedProjection);
    }
