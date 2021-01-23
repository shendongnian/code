    class Program
    {
    	static void Main(string[] args)
    	{
    		MyCustomType c = new MyCustomType();
    		c.Description = string.Format("Something like this {0}", (char)22);
    		var output = c.ToXMLString();
    		Console.WriteLine(output);
    	}
    }
    
    public class MyCustomType
    {
    	public string Description { get; set; }
    	static readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyCustomType));
    	public string ToXMLString()
    	{
    		var settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true, CheckCharacters = false };
    		StringBuilder sb = new StringBuilder();
    		using (var writer = XmlWriter.Create(sb, settings))
    		{
    			xmlSerializer.Serialize(writer, this);
    			return sb.ToString();
    		}
    	}
    }
