    using System.Configuration;
    
    namespace Abcd
    {
      // Generic implementation of ConfigurationElementCollection.
      [ConfigurationCollection(typeof(ConfigurationElement))]
      public class ConfigurationElementCollection<T> : ConfigurationElementCollection
                                             where T : ConfigurationElement, IConfigurationElement, new()
      {
        protected override ConfigurationElement CreateNewElement()
        {
          return new T();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
          return ((IConfigurationElement)element).GetElementKey();
        }
    
        public T this[int index]
        {
          get { return (T)BaseGet(index); }
        }
    
        public T GetElement(object key)
        {
          return (T)BaseGet(key);
        }
      }
    }
