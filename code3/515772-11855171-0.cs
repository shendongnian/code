    ZipFile zipFile = ZipFile.Read(zipPath); // the path is my desktop
    foreach (ZipEntry entry in zipFile)
    {
      if (entry.FileName == "myXML.xml")
      { 
        //creating the stream and loading the xml doc from the zip file:
        Stream stream = zipFile[entry.FileName].OpenReader();    
        XmlReader xReader = XmlReader.Create(stream);
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(xReader);
    
        //changing the inner text of the doc nodes:
        xDoc.DocumentElement.SelectSingleNode("Account/Name").InnerText = "VeXe";
        xDoc.DocumentElement.SelectSingleNode("Account/Money").InnerText = "Million$";
    
        using(var ms=new MemoryStream())
        using(var sw=new StreamWriter(ms))
        {
            xDoc.Save(sw);
            sw.Flush();
            ms.Position=0;
            zipFile.UpdateItem(entry.FileName,ms);
        }
        break;
      }
    }
