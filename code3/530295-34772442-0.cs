    public class JsonContent : StringContent
    {
    	public JsonContent(string content)
    		: this(content, Encoding.UTF8)
    	{
    	}
    
    	public JsonContent(string content, Encoding encoding)
    		: base(content, encoding, "application/json")
    	{
    	}
    }
    
    public class XmlContent : StringContent
    {
    	public XmlContent(string content) 
    		: this(content, Encoding.UTF8)
    	{
    	}
    
    	public XmlContent(string content, Encoding encoding)
    		: base(content, encoding, "application/xml")
    	{
    	}
    }
