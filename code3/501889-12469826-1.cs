    public static class XElementExtensions
    {
        public static string SafeAttributeValue(this XElement element, string attributeName)
        {
            XAttribute selectedAttribute = element.Attribute(attributeName);
            return selectedAttribute == null ? string.Empty : selectedAttribute.Value;
        }
        /// <summary>
        /// Returns the XML string of the <paramref name="xElement"/> WITHOUT CHARACTER CHECKING.
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static string ToStringWithoutCharacterChecking(this XElement xElement)
        {
            var xmlWriterSettings = new XmlWriterSettings { CheckCharacters = false };
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    xElement.WriteTo(xmlTextWriter);
                }
                return stringWriter.ToString();
            }
        }
    }
