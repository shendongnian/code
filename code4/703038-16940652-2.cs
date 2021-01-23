    public XElement GetSqlEyeDataElement(string elementName, SqlEyeData data)
    {
        var returnValue = new XElement(elementName,
            new XAttribute("Name", data.Name)
        );
        data.Filenames.ForEach(filename =>
        {
            returnValue.Add(new XElement("File",
                new XAttribute("Name", filename)));
        });
        return returnValue;
    }
