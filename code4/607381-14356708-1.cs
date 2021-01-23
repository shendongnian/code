    void Main()
    {
    	AutoMapper.Mapper.CreateMap<Dictionary<string, object>, dynamic>()
    	                 .ConstructUsing(CreateDynamicFromDictionary);
    			 
    	var dictionary = new Dictionary<string, object>();
    	dictionary.Add("Name", "Ilya");
    	
    	dynamic dyn = Mapper.Map<dynamic>(dictionary);
    
    	Console.WriteLine (dyn.Name);//prints Ilya
    }
    public dynamic CreateDynamicFromDictionary(IDictionary<string, object> dictionary)
    {
    	dynamic dyn = new ExpandoObject();
        var expandoDic = (IDictionary<string, object>)dyn;
    	
    	dictionary.ToList()
    	          .ForEach(keyValue => expandoDic.Add(keyValue.Key, keyValue.Value));
    	return dyn;
    }
