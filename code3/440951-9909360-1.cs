    public class MySettingsSection
    {
         public IEnumerable<MySetting> MySettings { get;set; }
    }
    
    public class MySetting
    {
        public string Name { get;set; }
        public string MyValue { get;set; }
    }
    
    public class MySettingsConfigurationHander : IConfigurationSectionHandler
    {
         public object Create(XmlNode startNode)
         {
              var mySettingsSection = new MySettingsSection();
    
              mySettingsSection.MySettings = (from node in startNode.Descendents()
                                             select new MySetting
                                             {
                                                Name = node.Attribute("name"),
                                                MyValue = node.Attribute("myValue")
                                             }).ToList();
       
             return mySettingsSection;
         }
    }
    
    public class Program
    {
        public static void Main()
        {
            var section = ConfigurationManager.GetSection("mySettings") as MySettingsSection;
    
            Console.WriteLine("Here are the settings for 'MySettings' :");
    
            foreach(var setting in section.MySettings)
            {
                Console.WriteLine("Name: {0}, MyValue: {1}", setting.Name, setting.MyValue);
            }
        }
    }
