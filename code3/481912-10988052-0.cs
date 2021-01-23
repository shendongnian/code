    Character someCharacter = // Create your character
    Dictionary<string, string> myDictionary = // Load XML and transform
    var properties = someCharacter.GetType().GetProperties();
    foreach(KeyValuePair<string, string> kvp in myDictionary)
    {
        var matchingProperty = properties.FirstOrDefault(x => x.PropertyName.ToLower() == kvp.Key.ToLower());
        if(matchingProperty != null)
        {
            matchingProperty.SetValue(character, kvp.Value, null); // make sure to type convert if necesary here, since kvp.Value is a string, etc
        }
    }
