    XmlDocument configurationXML = new XmlDocument();
    List<byte> byteArray = new List<byte>(webRequest.downloadHandler.data);
    
    foreach(byte singleByte in Encoding.UTF8.GetPreamble())
    {
         byteArray.RemoveAt(byteArray.IndexOf(singleByte));
    }
    string xml = System.Text.Encoding.UTF8.GetString(byteArray.ToArray());
           xml = xml.Replace("\\r", "");
           xml = xml.Replace("\\t", "");
