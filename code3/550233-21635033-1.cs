    var eventValidation = HapHelper.GetAttributeValue(htmlDocPreservation, "__EVENTVALIDATION", "value");
    
    public static string GetAttributeValue(HtmlDocument doc, string inputName, string attrName)
    {
        string result = string.Empty;
       
            var node = doc.DocumentNode.SelectSingleNode("//input[@name='" + inputName + "']");
            if (node != null)
            {
                result = node.Attributes[attrName].Value;
            }
        
        return result;
    }
