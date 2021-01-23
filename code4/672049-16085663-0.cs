    public static class XDocumentExtensions
    {
        public static IEnumerable<string> SplitByLength(this XDocument source, string elementName, int maxLength)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (string.IsNullOrEmpty(elementName))
                throw new ArgumentException("elementName cannot be null or empty.", "elementName");
            if (maxLength <= 0)
                throw new ArgumentException("maxLength has to be greater than 0.", "maxLength");
            return SplitByLengthImpl(source, elementName, maxLength);
        }
        private static IEnumerable<string> SplitByLengthImpl(XDocument source, string elementName, int maxLength)
        {
            var builder = new StringBuilder();
            foreach (var element in source.Root.Elements(elementName))
            {
                var currentElementString = element.ToString();
                if (builder.Length + currentElementString.Length > maxLength)
                {
                    if (builder.Length > 0)
                    {
                        yield return builder.ToString();
                        builder.Clear();
                    }
                    else
                    {
                        throw new ArgumentException(
                            "source document contains element with length greater than maxLength", "source");
                    }
                }
                builder.AppendLine(currentElementString);
            }
            if (builder.Length > 0)
                yield return builder.ToString();
        }
    }
