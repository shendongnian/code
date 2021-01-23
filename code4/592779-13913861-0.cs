    public static string[] GetResourceNames()
    {
        var asm = Assembly.GetEntryAssembly();
        string resName = asm.GetName().Name + ".g.resources";
        using (var stream = asm.GetManifestResourceStream(resName))
        using (var reader = new System.Resources.ResourceReader(stream))
        {
            return reader.Cast<DictionaryEntry>().Select(entry => (string)entry.Key).ToArray();
        }
    }
