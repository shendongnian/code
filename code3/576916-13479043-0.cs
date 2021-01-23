    public static class ResourceHelper
    {
    static public string FindNameFromResource(ResourceDictionary dictionary, object resourceItem)
    {
        foreach (object key in dictionary.Keys)
        {
            if (dictionary[key] == resourceItem)
            {
                return key.ToString();
            }
        }
        return null;
    }
    }
