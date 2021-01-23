    public class Settings
    {
        public string SettingOne { get; set; }
    
        public bool SettingTwo { get; set; }
    
    }
    
    public class DAL
    {
        public Settings Settings { get; private set; }
    
        public DAL(Settings settings)
        {
    
        }
    }
