     List<CategoryModel> categories = MovieDb.Categories
        .Select(category => new CategoryModel { Category = category.CategoryName, id = category.Id })
        .ToList();
    ViewBag.Category = new SelectList(categories, "Id", "Category")
    Category category = new Category()
    category = categories.First(p=>p.CategoryId == Id);
    category.Name = "New Name";
    MovieDb.Categories.SaveChanges(category);
    MovieDb.SaveChanges();
