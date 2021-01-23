        /// <summary>
        /// Example for how to extract the number from an xml string.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private string ExtractNumber(string xml)
        {
            // Extracted number.
            string number = string.Empty;
            // Input text
            xml = @"<string xmlns=""http://schemas.microsoft.com/2003/10/Serialization/"">2</string>";
            // The regular expression for the match.
            // You can use the parentesis to isolate the desired number into a group match. "(\d+?)"
            var pattern = @"<string.*?>(\d+?)</string>";
            // Match the desired part of the xml.
            var match = Regex.Match(xml, pattern);
            // Verify if the match has sucess.
            if (match.Success)
            {
                // Finally, use the group value to isolate the number.
                number = match.Groups[1].Value;
            }
            return number;
        }
