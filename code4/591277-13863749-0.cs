        /// <summary>
        /// Example for how to extract the group Id.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static string ExtractNumber(string xml)
        {
            // Extracted number.
            string groupId = string.Empty;
            // Input text
            xml = @"<a href=""/makeuppro/video?st.cmd=altGroupVideoAll&amp;st.groupId=oqxdtikenuenvnwuj0rxiwhgvyuvhjhzjrd&amp;st.directLink=on&amp;st.referenceName=makeuppro&amp;st._aid=NavMenu_AltGroup_Video""";
            // Here is the key, you have to use "?" after "(?<id>[^\"\"]+"
            // This is called "Lazy expression", and it is different from the "Greedy expression".
            // Lazy expression uses the "?", like ".*?\r". So it will match the expression until they find the first carriage return (\r).
            // If you use ".*\r" (Greedy Expression), it will match until they find the last carriage return of the input. Thats why you matched ("&amp;st.directLink=on&amp;st.referenceName=makeuppro"), because the last "&amp" is after "makeuppro" .
            // Here the correct pattern.
            var pattern = "groupId=(?<id>[^\"\"]+?)&amp";
            // Match the desired part of the input.
            var match = Regex.Match(xml, pattern);
            // Verify the match sucess.
            if (match.Success)
            {
                // Finally, use the group value to isolate desired value.
                groupId = match.Groups["id"].Value;
            }
            return groupId;
        }
