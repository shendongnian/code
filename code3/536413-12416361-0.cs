    private async void ReadTasks(string action)
    {
        // This is a fire and forget method
   
        StorageFile file = await GetXmlFile(xmlfilename);
       
        var ReadStream1 = await file.OpenStreamForReadAsync() as Stream;
        XDocument doc1 = new XDocument();
        doc1 = XDocument.Load(ReadStream1);
        ReadStream1.Dispose(); 
        .......
    }
     
    private async Task<StorageFile> GetXmlFile(string xmlfilename)
    {
        try
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(xmlfilename);
        }
        catch (FileNotFoundException)
        {
            file = await CreateXml(xmlfilename);
        }
        return file;
    }
    private async Task<StorageFile> CreateXML(string xmlfilename)
    {
        StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(xmlfilename, CreationCollisionOption.ReplaceExisting);
        using (var writeStream1 = await file2.OpenStreamForWriteAsync() as Stream)
        {
            XDocument doc1 = new XDocument(              
                                            new XDeclaration("1.0", "utf-8", "yes"),  
                                            new XElement("tasks", 
                                                new XElement("task",  
                                                    new XElement("title", "Wish you enjoy this App :)"),
                                                    new XElement("due", DateTime.Now.Date.ToString("yyyy/MM/dd")))));
            doc1.Save(writeStream1);
            await writeStream1.FlushAsync();
        }
        return file;
    }
 
