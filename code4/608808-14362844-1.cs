    var settings = ConfigurationManager.AppSettings;
    // Gets all the keys for values that are invalid boolean strings.
    var invalidKeys = from key in settings.Keys
                       where !settings[key].IsValidBooleanString()
                       select key;
     // If you want a list...
     var invalidKeyList = invalidKeys.ToList<string>();
     // If you want an array...
     var invalidKeyArray = invalidKeys.ToArray<string>();
