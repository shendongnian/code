    class CountriesConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return (objectType == typeof(List<Country>));
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var l = new List<Country>();
    		dynamic expando = new ExpandoObject();
    		var temp = expando as IDictionary<string, object>;
    		if (reader.TokenType == JsonToken.StartObject)
    		{
    			var newCountry = true;
    			while (reader.TokenType != JsonToken.EndObject)
    			{
    				if(newCountry)
    					reader.Read();
    				if (reader.TokenType == JsonToken.PropertyName)
    				{
    					if (reader.Value != null && reader.Value.ToString() != "countries")
    					{
    						if (!temp.ContainsKey("Id"))
    						{
    							newCountry = true;
    							int id = 0;
    							if (Int32.TryParse(reader.Value.ToString(), out id))
    								temp.Add("Id", id);
    						}
    						else
    						{
    							var propertyName = reader.Value.ToString();
    							reader.Read();
    							temp.Add(propertyName, reader.Value.ToString());
    						}
    						
    					}
    				}
    				else if (reader.TokenType == JsonToken.EndObject)
    				{
    					l.Add(Country.BuildCountry(expando));
    					temp.Clear();
    					reader.Read();
    					newCountry = false;
    				}
    			}
    			reader.Read();
    			while (reader.TokenType != JsonToken.EndObject)
    			{
    				reader.Read();
    			}
    		}
    
    		return l;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		//ToDo here we can decide to write the json as 
    		//if only has one attribute output as string if it has more output as list
    	}
    }
