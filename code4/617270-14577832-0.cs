var assembly = Assembly.GetExecutingAssembly();
    using (var stream = asssembly.GetManifestResourceStream("namespace.folder.filename))
    using (StreamReader reader = new StreamReader(stream))
    {
         string result = reader.ReadToEnd();
    }
