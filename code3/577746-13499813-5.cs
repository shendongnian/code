    public sealed class XmlConfigurator : IConfigurationSectionHandler
	{
		public XmlConfigurator()
		{
		}
		//<?xml version="1.0" encoding="utf-8" ?>
		//<configuration>
		//    <configSections>
		//        <section name="DispatchSettings" type="MyNamespace.XmlConfigurator, MyNamespace.Core" />
		//    </configSections>
		//    <DispatchSettings type="MyNamespace.DispatchSettings, MyNamespace.Core">
		//        <ServiceIsActive>True</ServiceIsActive>
		//        <DispatchProcessBatchSize>100</DispatchProcessBatchSize>
		//    </DispatchSettings>
		public object Create(object parent, object configContext, XmlNode section)
		{
			XPathNavigator navigator = null;
			String typeName = null;
			Type sectionType = null;
			XmlSerializer xs = null;
			XmlNodeReader reader = null;
			try
			{
				Object settings = null;
				if (section == null)
					return settings;
				navigator = section.CreateNavigator();
				typeName = (string)navigator.Evaluate("string(@type)");
				sectionType = Type.GetType(typeName);
				if (sectionType == null)
					throw new ArgumentException("Could not find the specified type: " + typeName);
				xs = new XmlSerializer(sectionType);
				reader = new XmlNodeReader(section);
				settings = xs.Deserialize(reader);
				return settings;
			}
			finally
			{
				xs = null;
			}
		}
	}
