    public class ViewFilterCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ViewFilterElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ViewFilterElement)element).Name;
        }
    }
