    public static class XmlExtensions
    {
        public static String ValueTrim(this XElement element)
        {
            return element != null ? element.Value.Trim() : "";
        }
    }
