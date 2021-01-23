    public interface IEngineController //I dont see a need to expose the enigine here in this pseudo code
    {
        void Start(); 
        IConfiguration Config { get; }
    }
    public interface IEngine
    {
        void Start();
    }
    public interface IConfiguration
    {
        bool IsOkToStart { get; }
    }
    public class Configuration : IConfiguration
    {
        public Configuration(List<IConfigurationParameter> configurationParameters)
        {
            ConfigurationParameters = configurationParameters;
        }
        public bool IsOkToStart
        {
            get { return ConfigurationParameters.All(cfg=>cfg.IsOkToStart); }
        }
        protected List<IConfigurationParameter> ConfigurationParameters { get; private set; }
    }
    public interface IConfigurationParameter
    {
        bool IsOkToStart { get; }
    }
    public interface IMaxTemp : IConfigurationParameter
    {
        double MaxTemp { get; }
    }
    public interface ISafetyParameter : IConfigurationParameter
    {
        ISafetyCondition SafetyCondition { get; }
    }
