    MyFileListConfiguration myConfig = (MyFileListConfiguration)ConfigurationManager.GetSection("MyFileSection");
    myConfig.Files[0] or myConfig.Files["MyFile1"] => .KeyName / .CopyType / .SourceFileName
            //  myConfig.Directories[0] or myConfig.Directories["MyDataLocation"] => .RootName / .RootLocation
    public class MyFileListConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("MyFileListCollection", IsDefaultCollection = false)]
        public MyFileListCollection Files
        {
            get { return ((MyFileListCollection)(base["MyFileListCollection"])); }
        }
        [ConfigurationProperty("MyDirectoryRootCollection", IsDefaultCollection = false)]
        public MyDirCollection Directories
        {
            get { return ((MyDirCollection)(base["MyDirectoryRootCollection"])); }
        }
    }
    [ConfigurationCollection(typeof(MyFileElement))]
    public class MyFileListCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyFileElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyFileElement)(element)).KeyName;
        }
        /// <summary>
        /// Access the collection by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MyFileElement this[int index]
        {
            get { return (MyFileElement)BaseGet(index); }
        }
        /// <summary>
        /// Access the collection by key name
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new MyFileElement this[string key]
        {
            get { return (MyFileElement)BaseGet(key); }
        }
    }
    [ConfigurationCollection(typeof(MyDirElement))]
    public class MyDirCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyDirElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyDirElement)(element)).RootName;
        }
        /// <summary>
        /// Access the collection by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MyDirElement this[int index]
        {
            get { return (MyDirElement)BaseGet(index); }
        }
        /// <summary>
        /// Access the collection by key name
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new MyDirElement this[string key]
        {
            get { return (MyDirElement)BaseGet(key); }
        }
    }
    public class MyFileElement : ConfigurationElement
    {
        [ConfigurationProperty("keyName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string KeyName
        {
            get { return ((string)(base["keyName"])); }
            set { base["keyName"] = value; }
        }
        [ConfigurationProperty("copyType", DefaultValue = "")]
        public string CopyType
        {
            get { return ((string)(base["copyType"])); }
            set { base["copyType"] = value; }
        }
        [ConfigurationProperty("sourceFileName", DefaultValue = "")]
        public string SourceFileName
        {
            get { return ((string)(base["sourceFileName"])); }
            set { base["sourceFileName"] = value; }
        }
    }
    public class MyDirElement : ConfigurationElement
    {
        [ConfigurationProperty("rootName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string RootName
        {
            get { return ((string)(base["rootName"])); }
            set { base["rootName"] = value; }
        }
        [ConfigurationProperty("rootLocation", DefaultValue = "")]
        public string RootLocation
        {
            get { return ((string)(base["rootLocation"])); }
            set { base["rootLocation"] = value; }
        }
    }
