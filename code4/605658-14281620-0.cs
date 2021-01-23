    List<string> PropertyNames = new List<string>()
    {
        "Prop1",
        "Prop2"
    };
    if (PropertyNames.Any(p => !ModelState.IsValidField(p)))
    {
        // Error
    }
    else
    {
        // Everything is okay
    }
