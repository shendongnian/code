    public int ModifyFile(string xmlpath, string option, int returnCode)
    {
       var fs = File.Open(xmlpath);
       XmlDocument xmlDoc = new XmlDocument();
       xmlDoc.Load(fs);  // use the stream, not file name
       fs.Close(); // now close the stream... file should not be locked from this point 
       XmlNode parentNode = xmlDoc.DocumentElement;
       if (option.Equals("delete"))
          {
              returnCode = DeleteTag(parentNode, "identity", returnCode);
          }
    
          xmlDoc.Save(path);
    
          return returnCode;
     }
