    var type = typeof(Status);
    var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
    Dictionary<string, string> dictionary = fields.ToDictionary(
        kvp => ((Status)kvp.GetValue(kvp)).GetValue(), 
        kvp => kvp.GetValue(kvp).ToString()
        );
