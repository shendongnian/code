    XDocument doc = XDocument.Load(...);
    var root = doc.Root;
    var builder = new SqlConnectionStringBuilder
    {
        DataSource = root.Element("server").Value,
        InitialCatalog = root.Element("initial_catalog").Value,
        UserID = root.Element("uid").Value,
        Password = root.Element("pwd").Value
    };
    var connectionString = builder.ToString();
