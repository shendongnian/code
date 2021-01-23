    public static class XElementExtension
    {
        public static string GetValueOrDefault(this XAttribute attribute,
                                               string defaultValue = null)
        {
            return attribute == null ? defaultValue : attribute.Value;
        }
        public static string GetAttributeValueOrDefault(this XElement element,
                                                        string attributeName, 
                                                        string defaultValue = null)
        {
            return element == null ? defaultValue : element.Attribut(attributeName)
                                                    .GetValueOrDefault(defaultValue);
        }
    }
