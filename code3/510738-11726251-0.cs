    public override string ToString()
    {
    	Type type = this.GetType();
    	FieldInfo[] fields = type.GetFields();
    	PropertyInfo[] properties = type.GetProperties();
    	User user = this;
    			
    	Dictionary<string, object> values = new Dictionary<string, object>();
    	Array.ForEach(fields, (field) => values.Add(field.Name, field.GetValue(user)));
    	Array.ForEach(properties, (property) =>
    		{
    			if (property.CanRead)
    				values.Add(property.Name, property.GetValue(user, null));
    		});
    
    	return String.Join(", ", values);
    }
