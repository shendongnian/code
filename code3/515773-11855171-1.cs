    using(ZipFile zipFile = ZipFile.Read(zipPath))
    foreach (ZipEntry entry in zipFile)
    {
      if (entry.FileName == "myXML.xml")
      { 
        //creating the stream and loading the xml doc from the zip file:
        using(Stream stream = zipFile[entry.FileName].OpenReader())
        using(XmlReader xReader = XmlReader.Create(stream))
        {    
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xReader);
        }
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
