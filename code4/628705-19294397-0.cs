    public static bool ContainsKey(this NameValueCollection collection, string key)
    {
        if (collection.AllKeys.Contains(key)) 
            return true;
         // ReSharper disable once AssignNullToNotNullAttribute
        var keysWithoutValues = collection.GetValues(null);
        return keysWithoutValues != null && keysWithoutValues.Contains(key);
    }
