    public class Settings : IDisposable
    {
        string file = "my settings file";
        XElement root;
        private Settings()
        { 
            root = XElement.Load(file);           
        }
        private void Dispose()
        {
            root.Save(file);
        }
    
        public static Settings Instance { get { return new Settings(); } } // return read-only version
    
        public static void Using(Action<Settings> handler)
        {
            using(Setting settings = new Settings())
                handler(settings);
        }
        // below here is implentation specific
        public XElement Root { get { return root; } }
        public string SettingA 
        { 
            get { return (string)(Root.Attribute("SettingA") ?? (object)string.Empty); }
            set { Set(Root, "SettingsA", value, true); }
        }
        // I wrote this for another StackOverflow thread
        /// <summary>
        /// Set any value via its .ToString() method.
        /// <para>Returns XElement of source or the new XElement if is an ELEMENT</para>
        /// </summary>
        /// <param name="isAttribute">true for ATTRIBUTE or false for ELEMENT</param>
        /// <returns>source or XElement value</returns>
        private XElement Set(XElement source, string name, object value, bool isAttribute)
        {
            string sValue = value.ToString();
            XElement eValue = source.Element(name), result = source;
            XAttribute aValue = source.Attribute(name);
            if (null != eValue)
                eValue.ReplaceWith(result = new XElement(name, sValue));
            else if (null != aValue)
                aValue.ReplaceWith(new XAttribute(name, sValue));
            else if (isAttribute)
                source.Add(new XAttribute(name, sValue));
            else
                source.Add(result = new XElement(name, sValue));
            return result;
        }
    }
