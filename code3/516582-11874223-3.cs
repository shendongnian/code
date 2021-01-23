    using (Db Db = new Db()) {
        var newCategories = new List<Category>();
        for (int i = 0; i < 10; i++) {
            Category category = newCategories.SingleOrDefault(x => x.Name == "Hello");
            if (category == null) {
                category = Db.Categories.SingleOrDefault(x => x.Name == "Hello");
                if (category == null) {
                    category = Db.Categories.Create();
                    category.Name = "Hello";
                    Db.Categories.Add(category);
                    newCategories.Add(category);
                    Console.WriteLine("Adding item...");
                }
            }
        }
    }
