    static class XExtensions
    {
        public static XElement ElementOrEmpty(this XContainer container, XName name)
        {
            return container.Element(name) ?? new XElement(name);
        }
    }
    var list = document.ElementOrEmpty("Items").Elements("Item").Select(Items.FromXElement).ToList();
