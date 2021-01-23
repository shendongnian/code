    public sealed class MySettingsProvider : SettingsProvider
    {
        public override string ApplicationName { get { return Application.ProductName; } set { } }
        public override string Name { get { return "MySettingsProvider"; } }
        public override void Initialize(string name, NameValueCollection col)
             { base.Initialize(ApplicationName, col); }
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propertyValues)
        {
           // Use an XmlWriter to write settings to file. Iterate PropertyValueCollection and use the SerializedValue member
        }
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {
           // Read values from settings file into a PropertyValuesCollection and return it
        }
        static MySettingsProvider()
        {
            appSettingsPath_ = Path.Combine(new FileInfo(Application.ExecutablePath).DirectoryName, settingsFileName_);
				
            settingsXml_ = new XmlDocument();
            try { settingsXml_.Load(appSettingsPath_); }
            catch (XmlException) { CreateXmlFile_(settingsXml_); } //Invalid settings file
            catch (FileNotFoundException) { CreateXmlFile_(settingsXml_); } // Missing settings file
        }
    }
    
