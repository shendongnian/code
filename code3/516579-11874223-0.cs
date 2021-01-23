    using (Db Db = new Db()) {
        var newCategories = new List<Category>();
        for (int i = 0; i < 10; i++) {
            Category Category = newCategories.SingleOrDefault(x => x.Name == "Hello");
            if (Category == null) {
                Category = Db.Categories.SingleOrDefault(x => x.Name == "Hello");
            }
            if (Category == null) {
                Category = Db.Categories.Create();
                Category.Name = "Hello";
                Db.Categories.Add(Category);
                newCategories.Add(Category);
                Console.WriteLine("Adding item...");
            }
        }
    }
