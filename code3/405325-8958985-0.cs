    ResourceManager resourceManager = new ResourceManager(typeof(Strings));
    IEnumerable<string> neutralResourceNames = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, false)
        .Cast<DictionaryEntry>().Select(entry => (string)entry.Key);
    IEnumerable<string> localizedResourceNames = resourceManager.GetResourceSet(new CultureInfo("es"), true, false)
        .Cast<DictionaryEntry>().Select(entry => (string)entry.Key);
    Console.WriteLine("Missing localized resources:");
    foreach (string name in neutralResourceNames.Except(localizedResourceNames))
    {
        Console.WriteLine(name);
    }
    Console.WriteLine("Extra localized resources:");
    foreach (string name in localizedResourceNames.Except(neutralResourceNames))
    {
        Console.WriteLine(name);
    }
