	using System;
	using System.Configuration;
	namespace TestConfigurationElement
	{
		public class ServicesMonitorSection : ConfigurationSection
		{
			[ConfigurationProperty("serviceTestGroups", IsRequired = true)]
			public ServiceTestGroupElementCollection ServiceTestGroups
			{
				get { return (ServiceTestGroupElementCollection)this["serviceTestGroups"]; }
				set { this["serviceTestGroups"] = value; }
			}
		}
		public class ServiceTestGroupElement : ConfigurationElement
		{
			[ConfigurationProperty("name", IsRequired = true)]
			public string Name
			{
				get { return (string)this["name"]; }
				set { this["name"] = value; }
			}
			[ConfigurationProperty("serviceTests", IsRequired = true)]
			public ServiceTestElementCollection ServiceTests
			{
				get { return (ServiceTestElementCollection)this["serviceTests"]; }
				set { this["serviceTests"] = value; }
			}
		}
		public class ServiceTestGroupElementCollection : ConfigurationElementCollection
		{
			protected override ConfigurationElement CreateNewElement()
			{
				return new ServiceTestGroupElement();
			}
			protected override object GetElementKey(ConfigurationElement element)
			{
				return ((ServiceTestGroupElement)element).Name;
			}
		}
		public class ServiceTestElement : ConfigurationElement
		{
			[ConfigurationProperty("uri", IsRequired = true)]
			public Uri Uri
			{
				get { return (Uri)this["uri"]; }
				set { this["uri"] = value; }
			}
			[ConfigurationProperty("expectedResponseTime", IsRequired = true)]
			public int ExpectedResponseTime
			{
				get { return (int)this["expectedResponseTime"]; }
				set { this["expectedResponseTime"] = value; }
			}
		}
		public class ServiceTestElementCollection : ConfigurationElementCollection
		{
			protected override ConfigurationElement CreateNewElement()
			{
				return new ServiceTestElement();
			}
			protected override object GetElementKey(ConfigurationElement element)
			{
				return ((ServiceTestElement)element).Uri;
			}
		}
		public static class Program
		{
			public static void Main(string[] args)
			{
				ServicesMonitorSection section = (ServicesMonitorSection)ConfigurationManager.GetSection("servicesMonitor");
			}
		}
	}
