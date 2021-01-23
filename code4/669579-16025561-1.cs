    ParseMessage(string xml)
    {
       XDocument doc = XDocument.Parse(xml);
       String rootName = doc.Root.Name;
    
       if (rootName == "SuccessMessageName")
       {  
           //Depending if you deserialize from an XDocument...
           ProcessSuccessMessage(doc);
           // or String.
           ProcessSuccessMessage(xml);
       }
       else if (rootName == "ErrorMessageName")
           //etc.
    }
