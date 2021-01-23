    Type type = Model.GetType(); // Model is the object you are binding with in your view
    PropertyInfo[] properties = type.GetProperties();
    foreach (var property in properties)
    {
        // Code to create your text box for the property
    }
