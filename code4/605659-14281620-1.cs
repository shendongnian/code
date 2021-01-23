    List<string> PropertyNames = new List<string>()
    {
        "Prop1",
        "Prop2"
    };
    if (PropertyNames.All(p => ModelState.IsValidField(p)))
    {
        // Everything is okay
    }
    else
    {
        // Error
    }
