    using (var stream = Assembly.GetExecutingAssembly()
           .GetManifestResourceStream(typeof(YourUnitTest), filename))
    using(var reader = new StreamReader(stream))
    {
        var fileContent = reader.ReadToEnd();
    }
