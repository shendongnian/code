    XElement root = XElement.Load(xmlpath);
    bool modified = false;
    try
    {
        switch(option)
        {
            case "delete":
                var toDelete = root.Descendants("identity").ToArray();
                foreach(XElement x in toDelete)
                {
                    x.Remove();
                    modified = true;
                    returnCode = 1;
                }
                break;
        }
    }
    finally
    {
        if(modified)
            root.Save(xmlpath);
    }
    return returnCode;
