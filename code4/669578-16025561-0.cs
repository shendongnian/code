    ParseMessage(string xml)
    {
        XDocument doc = XDocument.Parse(xml);
    
       if (doc.Root.Name == "SuccessMessageName")
       {  
           ProcessSuccessMessage(doc);
       }
       else if (doc.Root.Name == "ErrorMessageName")
           //etc.
    }
