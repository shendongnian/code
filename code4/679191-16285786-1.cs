    namespace MyApp
    {
    	class Program
    	{
    		static void Main(string[] args) {
    			var config = ConfigurationManager.GetSection(MyConfigurationSection.SectionName) as MyConfigurationSection ?? new MyConfigurationSection();
    
    			Console.WriteLine(config.MyValue);
    
    			Console.ReadLine();
    		}
    	}
    
    	public class MyConfigurationSection : ConfigurationSection
    	{
    		public const String SectionName = "registrations";
    
    		[ConfigurationProperty("myValue")]
    		public String MyValue {
    			get { return (String)this["myValue"]; }
    			set { this["myValue"] = value; }
    		}
    
    	}
    }
