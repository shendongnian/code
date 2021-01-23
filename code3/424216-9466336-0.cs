    var assembly = Assembly.GetExecutingAssembly();
    var key = assembly.GetName().Name + ".Manager.NLog.config";
    using (var inputStream = assembly.GetManifestResourceStream(key))
    using (var reader = new StreamReader(inputStream))
    {
        var result = reader.ReadToEnd();
    }
