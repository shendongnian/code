        public class ConfigProject
    {
        
        public ConfigTeam Team                      { get; set; }
        
        [DisplayName("Project Name")]
        public string Name                          { get; set; }
        
        [DisplayName("Project Description")]
        public string Description                   { get; set; }
        public List<ConfigSetting>      Settings      { get; set; }
    }
