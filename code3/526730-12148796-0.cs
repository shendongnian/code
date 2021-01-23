     // set category.Collection
     Category category = new Category { Collection = collection ...
     // set collection agin
     category.SetCollection(collection);
         // within SetCollection, you add the category
         collection.Categories.Add(this);
     // and add the category agin
     collection.AddCategory(category);
