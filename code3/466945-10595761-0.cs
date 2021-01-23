    public void UploadFile(string destinationFolderPath,
                          byte[] fileBytes,
                          string fileName,
                          bool overwrite,
                          string sourceFileUrl,
                          string lastVersionUrl)
    {
    List<Sharepoint.FieldInformation> fields = new List<Sharepoint.FieldInformation>();
    Sharepoint.FieldInformation fieldInfo;
    fieldInfo = new Sharepoint.FieldInformation();
    fieldInfo.Id = Microsoft.SharePoint.SPBuiltInFieldId.Title;
    fieldInfo.Value = "New title";
    fieldInfo.DisplayName = "Title";
    fieldInfo.Type = YetAnotherMigrationTool.Library.SP2007.Sharepoint.FieldType.Text;
    fieldInfo.InternalName = "Title";
    fields.Add(fieldInfo);
    string[] url;
    if (string.IsNullOrEmpty(destinationFolderPath))
        url = new string[] { string.Format("{0}/{1}/{2}", _siteUrl, _name, fileName) };
    else
        url = new string[] { string.Format("{0}/{1}/{2}{3}", _siteUrl, _name,    destinationFolderPath, fileName) };
    Sharepoint.CopyResult[] result;
    Sharepoint.Copy service = new Sharepoint.Copy();
    service.Url = _siteUrl + "/_vti_bin/Copy.asmx";
    service.Credentials = new NetworkCredential(Settings.Instance.User, Settings.Instance.Password);
    service.Timeout = 600000;
    uint documentId = service.CopyIntoItems(sourceFileUrl, url, fields.ToArray(), fileBytes, out result);
    }
    public void SetContentType(List<string> ids, string contentType)
    {
    ListsService.Lists service = new YetAnotherMigrationTool.Library.SP2007.ListsService.Lists();
    service.Url = _siteUrl + "/_vti_bin/Lists.asmx";
    service.Credentials = new NetworkCredential(Settings.Instance.User, Settings.Instance.Password);
    string strBatch = "";
    for (int i = 1; i <= ids.Count; i++)
    {
        strBatch += @"<Method ID='"+i.ToString()+@"' Cmd='Update'><Field Name='ID'>" + ids[i-1] + "</Field><Field Name='ContentType'>"+contentType+"</Field></Method>";
    }
    XmlDocument xmlDoc = new XmlDocument();
    XmlElement elBatch = xmlDoc.CreateElement("Batch");
    elBatch.SetAttribute("OnError", "Continue");
    elBatch.SetAttribute("ListVersion", "10");
    elBatch.SetAttribute("ViewName", "");
    elBatch.InnerXml = strBatch;
    result = service.UpdateListItems(_name, elBatch);
    }
