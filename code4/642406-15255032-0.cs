    ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    foreach (DictionaryEntry entry in resourceSet)
    {
        if (entry.Value is string)
        {
            if (entry.Value.ToString().Contains(x)) { /* etc. */ }
        }
    }
