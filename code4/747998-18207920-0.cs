    private static Dictionary<string, string> GetCustomDocumentProperties(WordprocessingDocument p_document)
        {            
            if (p_document.CustomFilePropertiesPart == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return p_document.CustomFilePropertiesPart.Properties.ToDictionary(p => ((CustomDocumentProperty) p).Name.InnerText,
                                                                              p => ((CustomDocumentProperty) p).InnerText);
            }
        }
