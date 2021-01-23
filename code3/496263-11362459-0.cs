            string input = String.Concat("<root>", @"<p></p><table><table><p></p></table></table>", "</root>");
            XDocument doc = XDocument.Parse(input);
            var valuesStr = doc.Root.Element("table").ToString();
            string[] values = Regex.Matches(valuesStr, @"<.*?>")
                .Cast<Match>()
                .Select(o => o.Groups[0].Value)
                .ToArray();
