	public sealed class Configuration
	{
	 public string Name { get; set; }
	 public Levels Level { get; set; }
	 public ConfigurationSpec Spec { get; set; }
	}
	 public abstract class ConfigurationSpec { }
	 public class ConfigurationSpec1	{	}
	public class ConfigurationSpec2	{	}
