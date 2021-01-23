    protected override void BaseAdd(ConfigurationElement element)
        {
     
     CustomConfigurationElement newElement = element as CustomConfigurationElement;
    
          if (base.BaseGetAllKeys().Where(a => (string)a == newElement.Key).Count() > 0)
          {
            CustomConfigurationElement currElement = this.BaseGet(newElement.Key) as CustomConfigurationElement;
    
            if (!string.IsNullOrEmpty(newElement.Local))
              currElement.Local = newElement.Local;
    
            if (!string.IsNullOrEmpty(newElement.Dev))
              currElement.Dev = newElement.Dev;
    
            if (!string.IsNullOrEmpty(newElement.Prod))
              currElement.Prod = newElement.Prod;
          }
          else
          {
            base.BaseAdd(element);
          }
        }
