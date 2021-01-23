    var items = _db.Items.OrderByDescending(x => x.ID).Select(x => new
    {
        ID = x.ID,
        Price = x.Price,
        Name = x.ItemTranslations.Where(y => y.Language.Name == UserLanguage).Select(y => y.Name).SingleOrDefault(),
        Category =  new {
            ID = x.Category.ID,
            Name = x.Category.CategoryTranslations.Where(y => y.Language.Name == lang).Select(y => y.Name).SingleOrDefault()
        }
    });
