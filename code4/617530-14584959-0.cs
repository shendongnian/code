    // Get the path to assembly directory.
    // There is a lot of alternatives: http://stackoverflow.com/questions/52797/
    string assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
    var directoryPath = Path.GetDirectoryName(assemblyPath);
    // Path to XML-file.
    var filePath = Path.Combine(directoryPath, "ExceptionLog.xml");
    using (var xmlTextWriter = new XmlTextWriter(filePath, Encoding.UTF8))
    {
        ...
    }
