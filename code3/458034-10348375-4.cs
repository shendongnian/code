    public static class ConfigurationHelper
    {
        public static IList<Element> AddElement(this IList<Element> elements, Element element)
        {
            elements.Add(element);
            return elements;
        }
    
        public static Config WrapToConfig(this IList<Element> elements)
        {
            return Config(elements);
        }
    }
