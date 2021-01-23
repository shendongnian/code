    public class ClassThatUsesSettingsFactory
    {
        private readonly SettingsFactory _settingsFactory;
    
        public ClassThatUsesSettingsFactory(SettingsFactory settingsFactory)
        {
           _settingsFactory = settingsFactory;
        }
    
        public void MethodThatCallsSettingsFactory()
        {
           //... do something
           var settings = _settingsFactory.CreateOrGetSettings();
           //... do something
        }
    }
