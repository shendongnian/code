    public object[] GetValues(string propertyName)
    {
    	List<object> result = new List<object>();
    	PropertyInfo propertyInfo = typeof(Person).GetProperty(propertyName);
    	this.ForEach(person => result.Add(propertyInfo.GetValue(person)));
    	return result.ToArray();
    }
