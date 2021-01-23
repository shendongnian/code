    static XmlNode   XML_Array_Load(Dictionary<string, string> Data_Array, Dictionary<string, string> Elements_Array)
        {
            // XML File
            String xmlfile = Data_Array["XML_File"];
    
            // XML Page Check
            if (File.Exists(xmlfile))
            {
                XmlDocument doc = new XmlDocument();
                // If Page Exist Load XML File
                doc.Load(xmlfile);
    
                foreach (KeyValuePair<string, string> Element in Elements_Array)
                {
                    // Get Element From Dictionary Array
                    String Element_Name = Element.Key;
                    String Element_Type = Element.Value;
    
                    // Get Element_Name from XMLFile
                    String Value = String.Format("XMLFILE/{0}", Element_Name);
    
                    // Get Element_Name Value From XMLFile
                    XmlNode Element_Value = doc.SelectSingleNode(Value);
    
                    // Check If Element_Value Is Null Or Not
                    if (Element_Value != null)
                    {
                        return Element_Value;
                    }
    
                }
            }
         
            return null;
        }
