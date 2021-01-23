    public static string GetLocalizedNameReversed(string value)
    {
        ResourceManager rm = new ResourceManager($"YourNamespace.YourFolder.YourResourceFileName", assembly);
        var entry = rm.GetResourceSet(new CultureInfo("nb-NO"), true, true)
                .OfType<DictionaryEntry>()
                .FirstOrDefault(e => e.Value.ToString().Equals(value, StringComparison.OrdinalIgnoreCase));
        return entry.Key.ToString();
    }
