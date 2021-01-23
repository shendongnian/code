    public class CityList
    {
    	public List<City> city { get; set; }
    	public bool success { get; set; }
    }
    
    public class City
    {
    	public string city_id { get; set; }
    	public string City_Name { get; set; }
    	public string City_Image { get; set; }
    }
    
    public class Program
    {
    	private static void Main(string[] args)
    	{
    		var input = YOUR_STRING;
    
    		DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CityList));
    		using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input)))
    		{
    			var zz = serializer.ReadObject(ms);
    		}
    	}
    }
