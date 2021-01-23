    public class AppConfig : BaseAppConfig<SubConfig>
    {
    	public const string SECTION_KEY = "AppConfig";
    
    	public static IAppConfig Instance
    	{
    		get { return (IAppConfig)ConfigurationManager.GetSection(SECTION_KEY); }
    	}
    }
    
    public class SubConfig : ConfigurationElement
    {
    	[ConfigurationProperty("supProp1")]
    	public string SubProp1
    	{
    		get { return (string)this["supProp1"]; }
    		set { this["supProp1"] = value; }
    	}
    }
