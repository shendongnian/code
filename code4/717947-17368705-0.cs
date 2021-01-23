    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EnterpriseLibraryContainer.Current.GetInstance<LogWriter>()
                .Write("test", "General");
            string path = "C:\\Logs\\anotherlogfile.log";
            SetLogFilePath(path);
            EnterpriseLibraryContainer.Current.GetInstance<LogWriter>()
                .Write("Another test", "General");
        }
        public void SetLogFilePath(string filePath)
        {
            ConfigurationFileMap objConfigPath = new ConfigurationFileMap();
            // App config file path.
            string appPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            objConfigPath.MachineConfigFilename = appPath;
            Configuration entLibConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            LoggingSettings loggingSettings = (LoggingSettings)entLibConfig.GetSection(LoggingSettings.SectionName);
            TraceListenerData traceListenerData = loggingSettings.TraceListeners.Get("Flat File Trace Listener");
            FlatFileTraceListenerData objFlatFileTraceListenerData = traceListenerData as FlatFileTraceListenerData;
            objFlatFileTraceListenerData.FileName = filePath;
          
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<EnterpriseLibraryCoreExtension>();
            // Configurator will read Enterprise Library configuration 
            // and set up the container
            UnityContainerConfigurator configurator = new UnityContainerConfigurator(container);
            var loggingXmlConfigSource = new SerializableConfigurationSource();
            loggingXmlConfigSource.Add(LoggingSettings.SectionName, loggingSettings);
            // Configure the container with our own custom logging
            EnterpriseLibraryContainer.ConfigureContainer(configurator, loggingXmlConfigSource);
            // Wrap in ServiceLocator
            IServiceLocator locator = new UnityServiceLocator(container);
            // And set Enterprise Library to use it
            EnterpriseLibraryContainer.Current = locator;
        }
    }
    public class SerializableConfigurationSource : IConfigurationSource
    {
        Dictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
        public SerializableConfigurationSource()
        {
        }
        public ConfigurationSection GetSection(string sectionName)
        {
            ConfigurationSection configSection;
            if (sections.TryGetValue(sectionName, out configSection))
            {
                SerializableConfigurationSection section = configSection as SerializableConfigurationSection;
                if (section != null)
                {
                    using (StringWriter xml = new StringWriter())
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(xml))
                    {
                        section.WriteXml(xmlwriter);
                        xmlwriter.Flush();
                        MethodInfo methodInfo = section.GetType().GetMethod("DeserializeSection", BindingFlags.NonPublic | BindingFlags.Instance);
                        methodInfo.Invoke(section, new object[] { XDocument.Parse(xml.ToString()).CreateReader() });
                        return configSection;
                    }
                }
            }
            return null;
        }
        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            sections[sectionName] = configurationSection;
        }
        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }
        public void Remove(string sectionName)
        {
            sections.Remove(sectionName);
        }
        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            throw new NotImplementedException();
        }
        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;
        public void Dispose()
        {
        }
    }
