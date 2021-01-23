    public interface IFileConverter
    {
        bool Convert(string filePath);
    }
    
    
    public static class FileConverterFactory
    {
        public static IFileConverter Create(string extension)
        {
    		extension = type.ToUpper();
    
    		Dictionary<string, ConverterConfig> availableConverters = GetConvertersConfig();
    
    		if (!availableConverters.ContainsKey(extension))
    			throw new ArgumentException(string.Format("Unknown extenstion type '{0}'. Check application configuration file.", extension));
    
    		ConverterConfig cc = availableConverters[extension];
    		Assembly runnerAssembly = Assembly.LoadFrom(cc.Assembly);
    		Type converterType = runnerAssembly.GetType(cc.Class);
    
    		IFileConverter converter = (IFileConverter) Activator.CreateInstance(converterType);
    
    		return converter;
        }
    
    	
    	private static Dictionary<string, ConverterConfig> GetConvertersConfig()
    	{
    		var configs = (Dictionary<string, ConverterConfig>) ConfigurationManager.GetSection("ConvertersConfig");
    
    		return configs;
    	}
    }
    
    
    public class ConvertersConfigHandler : IConfigurationSectionHandler
    {
    	public object Create(object parent, object configContext, XmlNode section)
    	{
    		Dictionary<string, ConverterConfig> converters = new KeyedList<string, ConverterConfig>();
    		XmlNodeList converterList = section.SelectNodes("Converter");
    
    		foreach (XmlNode converterNode in converterList)
    		{
    			XmlNode currentConverterNode = converterNode;
    
    			ConverterConfig cc = new ConverterConfig();
    			cc.Type = XML.GetAttribute(ref currentConverterNode, "Type").ToUpper();
    			cc.Assembly = XML.GetAttribute(ref currentConverterNode, "Assembly");
    			cc.Class = XML.GetAttribute(ref currentConverterNode, "Class");
    
    			converters[cc.Type] = cc;
    		}
    
    		return converters;
    	}
    }
    
    	
    public class ConverterConfig
    {
    	public string Type = "";
    	public string Assembly = "";
    	public string Class = "";
    }
    
    
    public class TextConverter : IFileConverter
    {
       bool Convert(string filePath) { ... }
    }
    
    
    public class PdfConverter : IFileConverter
    {
       bool Convert(string filePath) { ... }
    }
