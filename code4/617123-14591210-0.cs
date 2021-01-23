	public class StandardConfigurationBase : ConfigurationSection
	{
		public static StandardConfigurationBase GetInstance()
		{
			return (StandardConfigurationBase) ConfigurationManager.GetSection("customConfigSection");
		}
		[ConfigurationProperty("childConfig")]
		public StandardChildConfig ChildConfig
		{
			get { return (StandardChildConfig) this["childConfig"]; }
			set { this["childConfig"] = value; }
		}
	}
	public class StandardConfiguration<TChildConfig> : StandardConfigurationBase
	where TChildConfig : StandardChildConfig
	{
		[ConfigurationProperty("childConfig")]
		public new TChildConfig ChildConfig
		{
			get { return (TChildConfig)this["childConfig"]; }
			set { this["childConfig"] = value; }
		}
	}
	public class StandardChildConfig : ConfigurationElement
	{
		[ConfigurationProperty("p1")]
		public string P1
		{
			get { return (string)this["p1"]; }
			set { this["p1"] = value; }
		}
	}
