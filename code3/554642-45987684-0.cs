        /// <summary>
        /// Escapes Json string to be included in an XML attribute
        /// </summary>
        /// <param name="jsonString">json string</param>
        /// <returns></returns>
        public static string EscapeJson(string jsonString)
        {
            return SecurityElement.Escape(jsonString);
        }
        /// <summary>
        /// Unescapes Json string from XML attribute value
        /// </summary>
        /// <param name="xmlString">xml string</param>
        /// <returns></returns>
        public static string UnescapeJson(string xmlString)
        {
            return new SecurityElement("", xmlString).Text;
        }
