    var values = new NameValueCollection { { "ID", "1" }, {"Name": "Bob"} }; // etc.
    var collection = new FormCollection(values);
    // or...
    // var collection = new FormCollection();
    // collection.Add("ID", "1");
    // collection.Add("Name", "Bob");
    // etc.
    
    TryUpdateModel(userToUpdate, new string[] { "ID", "Name", "Age", "Gender" }, form);
