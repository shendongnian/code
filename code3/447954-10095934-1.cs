    void Main()
    {
    	var dicEntityRules = new Dictionary<int, string>();
    
    	dicEntityRules.Add(1, "One");
    
        // Convert to List<Order>
    	var orders = dicEntityRules.Select (er => 
            new Order {entity=er.Key, rule=er.Value}).ToList();
    	
    	var serializer = new DataContractSerializer(typeof(List<Order>));
    	
    	using (var sw = new StringWriter())
    	{
    		using (XmlTextWriter writer = new XmlTextWriter(sw))
    		{                    
    			writer.Formatting = Formatting.Indented;
    		
    			serializer.WriteObject(writer, orders);
    		
    			writer.Flush();
    		
    			var s = sw.ToString();
    		}
    	}
    }
    
    [DataContract()]
    public class Order
    {
        [DataMember]
    	public int entity { get; set; }
    	[DataMember]
    	public string rule { get; set; }
    }
