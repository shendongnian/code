    public class AddElementCollection : ConfigurationElementCollection 
    {
        protected override ConfigurationElement CreateNewElement() 
        {
            return new AddElement();
        }
        protected override object GetElementKey(ConfigurationElement element) {
            return ((AddElement) element).Name;
        }
    }
