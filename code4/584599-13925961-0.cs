    DataSet untypedds = new DataSet();
    try {
        untypedds.ReadXml(xmlPath, XmlReadMode.ReadSchema);
    }
    catch (FileLoadException) {
        untypedds = new DataSet(); // Need the new DataSet here
        RewriteXml(xmlPath);
        untypedds.ReadXml(xmlPath, XmlReadMode.ReadSchema);
    }
