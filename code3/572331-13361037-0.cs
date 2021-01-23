    PropertyInfo pcFileProperty = download.GetType().GetProperty("PCFile");
    if (pcFileProperty == null)
    {
        pcFileProperty = download.GetType().GetProperty("pcFile");
    }
    if (pcFileProperty != null)
    {
        PCFileType file = (PCFileType)pcFileProperty.GetValue(download, null);
        file.Name = tempFileName;
        file.FileType = delimiterType;
    }
    else
    {
        // Property not found - IBM has changed the API again?
        // Throw an exception?
    }
