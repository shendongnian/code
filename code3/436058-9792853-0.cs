    // Method:
    public static object OrNullAsString(this object input, string defaultValue)
    {
        return input == null ? defaultValue : input;
    }
    // Example:
    var y = Session["key"].OrNullAsString("defaultValue");
