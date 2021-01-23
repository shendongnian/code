public class SomeData2
{
	public string Id { get; set; }
	public List&lt;SomeDataPair&gt; Data { get; set; }
}
public class SomeDataPair
{
	public string Key { get; set; }
	public string Value { get; set; }
}
private static void Main(string[] args)
{
	var json = "{ \"id\": \"123\", \"data\": [ { \"key1\": \"val1\" }, { \"key2\" : \"val2\" } ] }";
	var rawObj = JObject.Parse(json);
	var obj2 = new SomeData2
	{
		Id = (string)rawObj["id"],
		Data = new List&lt;SomeDataPair&gt;()
	};
	foreach (var item in rawObj["data"])
	{
		foreach (var prop in item)
		{
			var property = prop as JProperty;
			if (property != null)
			{
				obj2.Data.Add(new SomeDataPair() { Key = property.Name, Value = property.Value.ToString() });
			}
		}
	}
}
