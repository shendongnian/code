    public class ExtAppConfig : BaseAppConfig<ExtSubConfig>
    {
    	public static ExtAppConfig Instance
    	{
    		get { return (ExtAppConfig)AppConfig.Instance; }
    	}
    
    	[ConfigurationProperty("extAppProp1")]
    	public string ExtAppProp1
    	{
    		get { return (string)this["extAppProp1"]; }
    		set { this["extAppProp1"] = value; }
    	}
    }
    
    public class ExtSubConfig : SubConfig
    {
    	[ConfigurationProperty("extSubProp1")]
    	public string ExtSubProp1
    	{
    		get { return (string)this["extSubProp1"]; }
    		set { this["extSubProp1"] = value; }
    	}
    }
