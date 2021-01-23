    public class Request<TConfig> where TConfig : RequestConfiguration
    {
        private TConfig _config;
        public virtual TConfig Config
        {
            get { return _config ?? (_config = ConfigurationManager.GetSection("RequestConfig") as TConfig); }
        }
        public virtual string DoSomething()
        {
            return "Url:" + Config.Url;
        }
    }
    public class AuthRequest : Request<AuthRequestConfiguration>
    {
        public override string DoSomething()
        {
            return String.Format("Url:{0} U:{1} P:{2}", Config.Url, Config.User, Config.Pass);
        }
    }
    public class RequestConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get { return (string) this["Url"]; }
        }
    }
    public class AuthRequestConfiguration : RequestConfiguration
    {
        [ConfigurationProperty("User", IsRequired = true)]
        public string User
        {
            get { return (string) this["User"]; }
        }
        [ConfigurationProperty("Pass", IsRequired = true)]
        public string Pass
        {
            get { return (string) this["Pass"]; }
        }
    }
