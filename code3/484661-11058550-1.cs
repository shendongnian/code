    var type = typeof(Status);
    var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
    Dictionary<string, string> dictionary = fields.ToDictionary(
        kvp => kvp.Name,
        kvp => kvp.GetValue(kvp).ToString());
