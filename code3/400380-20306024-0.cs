    public class CustomCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CustomElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CustomElement)element).Name;
        }
        public CustomElement this[int index]
        {
            get { return (CustomElement)base.BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }
        // ConfigurationElement this[string] now becomes hidden in child class
        public new CustomElement this[string name]
        {
            get { return (CustomElement)BaseGet(name); }
        }
        // ConfigurationElement this[string] is now exposed
        // however, a value must be entered in second argument for property to be access
        // otherwise "this[string]" will be called and a CustomElement returned instead
        public object this[string name, string str = null]
        {
            get { return base[name]; }
            set { base[name] = value; }
        }
    }
