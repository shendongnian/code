    XDocument xdoc = new XDocument();
    
    .... // do your stuff here
    
    string finalDoc = xdoc.ToString();
    string header = finalDoc.Substring(0,finalDoc.IndexOf("?>") + 2); // end of header tag
    string encoding = header.Substring(header.IndexOf("encoding=") + 10);
    encoding = encoding.Substring(0,encoding.IndexOf("\""); // only get encoding content
    
    // replace encoding with the uppercase version in header, then replace old header with new one.
    finalDoc = finalDoc.Replace(header, header.Replace(encoding, encoding.ToUpper()));
    
    .... // do stuff with the xml with the upper case header
