    public void ReadXMLFile(int TFType)
    {
            XDocument doc = null;
    
            if (TFType == 1)
                reader = XDocument.Parse(MyProject.Properties.Resources.ID01);
            else if (TFType == 2)
                reader = XDocument.Parse(MyProject.Properties.Resources.ID02);
    
    
            // Now use 'doc' as an XDocument object
    }
