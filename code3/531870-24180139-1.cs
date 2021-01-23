    public class SomePropertyDecimalFormatConverter : DecimalFormatJsonConverter
    {
    	public SomePropertyDecimalFormatConverter() : base(3)
    	{
    	}
    }
    
    public class Poco 
    {
    	[JsonConverter(typeof(SomePropertyDecimalFormatConverter))]
    	public decimal SomeProperty { get;set; }
    }
