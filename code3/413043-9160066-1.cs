        /// <remarks>
        /// (angle brackets replaced with round ones to avoid confusing the XML-based documentation comments format)
        /// 
        /// Let input XML be:
        /// 
        ///     (root)
        ///         (days)3(/days)
        ///     (/root)
        ///     
        /// Calling Reposition on this input with mappings argument being:
        ///     (key) "days"
        ///     (value) { "time", "days" }
        ///     
        /// Returns:
        /// (root)
        ///     (time days="3" /)
        /// (/root)
        /// </remarks>        
        static XElement Reposition(XElement input, KeyValuePair<string, string[]>[] mappings)
        {
            var result = new XElement(input);
            foreach (var mapping in mappings)
            {
                var element = result.Element(mapping.Key);
                if (element == null)
                {
                    continue;
                }
                var value = element.Value;
                element.Remove();
                var insertAt = result;
                foreach (var breadcrumb in mapping.Value)
                {
                    if (breadcrumb == mapping.Value.Last())
                    {
                        insertAt.Add(new XAttribute(breadcrumb, value));
                    }
                    else
                    {
                        insertAt.Add(new XElement(breadcrumb));
                        insertAt = insertAt.Element(breadcrumb);
                    }
                }
            }
            return result;
        }
