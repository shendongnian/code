    public sealed class Settings
    {
        private static readonly HashSet<string> _propertiesForEncrypt = new HashSet<string>(new string[] { "StringProperty", "Password" });
        private static readonly Lazy<Settings> _instance = new Lazy<Settings>(() => new Settings());
        private Dictionary<string, object> m_lProperties = new Dictionary<string, object>();
    
        public void Load(string fileName)
        {
            // TODO: When you deserialize property which contains into "_propertiesForEncrypt" than Decrypt this property.
            throw new NotImplementedException();
        }
    
        public void Save(string fileName)
        {
            // TODO: When you serialize property which contains into "_propertiesForEncrypt" than Encrypt this property.
            throw new NotImplementedException();
        }
    
        public void Update()
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Gets the propery.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public object GetPropery(string propertyName)
        {
            if (m_lProperties.ContainsKey(propertyName))
                return m_lProperties[propertyName];
    
            return null;
        }
    
        /// <summary>
        /// Gets the propery.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public object GetPropery(string propertyName, object defaultValue)
        {
            if (m_lProperties.ContainsKey(propertyName))
            {
                return m_lProperties[propertyName].ToString();
            }
            else
            {
                SetProperty(propertyName, defaultValue);
                return defaultValue;
            }
        }
    
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public void SetProperty(string propertyName, object value)
        {
            if (m_lProperties.ContainsKey(propertyName))
                m_lProperties[propertyName] = value;
            else
                m_lProperties.Add(propertyName, value);
        }
    
    
        // Sample of string property
        public string StringProperty
        {
            get
            {
                return GetPropery("StringProperty") as string;
            }
            set
            {
                SetProperty("StringProperty", value);
            }
        }
    
        // Sample of int property
        public int IntProperty
        {
            get
            {
                object intValue = GetPropery("IntProperty");
                if (intValue == null)
                    return 0; // Default value for this property.
    
                return (int)intValue;
            }
            set
            {
                SetProperty("IntProperty", value);
            }
        }
    }
