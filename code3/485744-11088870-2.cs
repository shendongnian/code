    var collection = new FormCollection();
    collection.Add("User.ID", "1");
    collection.Add("User.Name", "Bob");
    // Binds to fields with the prefix "User"
    TryUpdateModel(userToUpdate, "User", new string[] { "ID", "Name", "Age", "Gender" }, null, form);
