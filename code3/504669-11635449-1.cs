    //place this somewhere in your project's namespace
    public static class MyExtensions
    {
        public static IEnumerable<XElement> ElementsAnyNS(this XElement source, string localName)
        {
            return source.Elements().Where(e => e.Name.LocalName == localName);
        }
        public static XElement ElementAnyNS(this XElement source, string localName)
        {
            return source.Elements().Where(e => e.Name.LocalName == localName).Select(e => e).Single();
        }
    }
