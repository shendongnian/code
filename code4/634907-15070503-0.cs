    ResourceSet rs = ResourceName.ResourceManager.GetResourceSet(
        Thread.CurrentThread.CurrentUICulture, true, true);
    Dictionary<string, object> resources = rs.Cast<DictionaryEntry>().ToDictionary(r => (string) r.Key, r => r.Value);
    // Can now list all keys, e.g.:
    foreach (string key in resources.Keys)
    {
        Debug.WriteLine(key);
    }
    // ...or can find out whether a key is present:
    object v;
    if (resources.TryGetValue("Key", out v))
    {
        Debug.WriteLine(v);
    }
