    public class Measurements
    {
    	[JsonProperty(ItemConverterType = typeof(RoundingJsonConverter))]
    	public List<double> Positions { get; set; }
    
    	[JsonProperty(ItemConverterType = typeof(RoundingJsonConverter), ItemConverterParameters = new object[] { 0, MidpointRounding.ToEven })]
    	public List<double> Loads { get; set; }
    
    	[JsonConverter(typeof(RoundingJsonConverter), 4)]
    	public double Gain { get; set; }
    }
