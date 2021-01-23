    if(File.Exists(filePath))
    {
         File.SetAttributes(filePath,FileAttributes.Normal);
         FileIOPermission filePermission = 
                  new FileIOPermission(FileIOPermissionAccess.AllAccess,filePath);
                        
         using(FileStream fs = new FileStream(filePath, FileMode.Create))
         {
             using (XmlWriter w = XmlWriter.Create(fs))
             {
                 w.WriteStartElement("book");
                 w.WriteElementString("price", "19.95");
                 w.WriteEndElement();
                 w.Flush();
             }
         }     
     }
