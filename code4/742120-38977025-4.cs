    public class MyClassThatDependsOnSomeSettings
    {
        private readonly ISettings _settings;
        public MyClassThatDependsOnSomeSettings(ISettings settings)
        {
            _settings = settings;
        }
        public void DoSomething()
        {
            var settingA = _settings.SettingA;
        }
    }
    public interface ISettings
    {
        int SettingA {get;}
        string SettingB {get;}
    }
