    public interface IAppConfig
    {
    	string AppProp1 { get; }
    	SubConfig SubConfig { get; }
    }
    
    public abstract class BaseAppConfig<TSubConfig> : ConfigurationSection, IAppConfig
        where TSubConfig : SubConfig
    {
    	[ConfigurationProperty("appProp1")]
    	public string AppProp1
    	{
    		get { return (string)this["appProp1"]; }
    		set { this["appProp1"] = value; }
    	}
    
    	[ConfigurationProperty("subConfig")]
    	public TSubConfig SubConfig
    	{
    		get { return (TSubConfig)this["subConfig"]; }
    		set { this["subConfig"] = value; }
    	}
    
    	// Implement the interface
    	string IAppConfig.AppProp1 { get { return this.AppProp1; } }
    	SubConfig IAppConfig.SubConfig { get { return this.SubConfig; } }
    }
