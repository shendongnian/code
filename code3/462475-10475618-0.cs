        public class SharedGroupConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the style sheets.
        /// </summary>
        /// <value>The style sheets.</value>
        [ConfigurationProperty("styleSheets", Options = ConfigurationPropertyOptions.IsRequired)]        
        public StyleSheetConfigurationElementCollection StyleSheets
        {
            get
            {
                return (StyleSheetConfigurationElementCollection)base["styleSheets"] ?? new StyleSheetConfigurationElementCollection();
            }
        }
        /// <summary>
        /// Gets the style sheets.
        /// </summary>
        /// <value>The style sheets.</value>
        [ConfigurationProperty("scripts", Options = ConfigurationPropertyOptions.IsRequired)]        
        public ScriptConfigurationElementCollection Scripts
        {
            get
            {
                return (ScriptConfigurationElementCollection)base["scripts"] ?? new ScriptConfigurationElementCollection();
            }
        }
    }
    
    
    [ConfigurationCollection(typeof(GroupConfigurationElementCollection), AddItemName = "group")]
    public class ScriptConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new GroupConfigurationElementCollection();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return ((GroupConfigurationElementCollection)element).Name;
        }
    }
    
    [ConfigurationCollection(typeof(GroupConfigurationElementCollection), AddItemName="group")]
    public class StyleSheetConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new GroupConfigurationElementCollection();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return ((GroupConfigurationElementCollection)element).Name;
        }
    }
    
    [ConfigurationCollection(typeof(AssetConfigurationElement), AddItemName = "asset", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class GroupConfigurationElementCollection : ConfigurationElementCollection
    {
        public GroupConfigurationElementCollection()
        {
            AddElementName = "asset";
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new AssetConfigurationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            return ((AssetConfigurationElement)element).Source;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name 
        {
            get
            {
                return (string)base["name"];
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebAssetGroupConfigurationElement"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get
            {
                return (bool)this["enabled"];
            }
            set
            {
                this["enabled"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [ConfigurationProperty("version")]
        public string Version
        {
            get
            {
                return (string)this["version"];
            }
            set
            {
                this["version"] = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebAssetGroupConfigurationElement"/> is compress.
        /// </summary>
        /// <value><c>true</c> if compress; otherwise, <c>false</c>.</value>
        [ConfigurationProperty("compress", DefaultValue = true)]
        public bool Compress
        {
            get
            {
                return (bool)this["compress"];
            }
            set
            {
                this["compress"] = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebAssetGroupConfigurationElement"/> is combined.
        /// </summary>
        /// <value><c>true</c> if combined; otherwise, <c>false</c>.</value>
        [ConfigurationProperty("combined", DefaultValue = true)]
        public bool Combined
        {
            get
            {
                return (bool)this["combined"];
            }
            set
            {
                this["combined"] = value;
            }
        }
    }
    
    public class AssetConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        [ConfigurationProperty("source", IsRequired = false, IsKey = false)]
        public string Source
        {
            get
            {
                return (string)this["source"];
            }
            set
            {
                this["source"] = value;
            }
        }
    }
