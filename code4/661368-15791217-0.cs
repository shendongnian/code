public class SomeData
{
	public string Id { get; set; }
	public IEnumerable&lt;IDictionary&lt;string, string&gt;&gt; Data { get; set; }
}
private static void Main(string[] args)
{
	var json = "{ \"id\": \"123\", \"data\": [ { \"key1\": \"val1\" }, { \"key2\" : \"val2\" } ] }";
	var obj = JsonConvert.DeserializeObject&lt;SomeData&gt;(json);
}
