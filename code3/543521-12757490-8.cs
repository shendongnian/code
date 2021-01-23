    /// <summary>
    /// Reads a record from a SqlDataReader, binds it to a model, and adds the object to the results parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reader"></param>
    /// <param name="modelName"></param>
    /// <param name="results"></param>
    private void ReadAs<T>(SqlDataReader reader, string modelName, List<T> results, string commandText) 
    {
    	Dictionary<string, object> _result = new Dictionary<string, object>();
    	for (int i = 0; i < reader.FieldCount; i++)
    	{
    		string _key = modelName + "." + reader.GetName(i);
    		object _value = reader.GetValue(i);
    
    		if (_result.Keys.Contains(_key))    // Dictionaries may not have more than one instance of a key, but a query can return the same column twice
    		{                                   // Since we are returning a strong type, we ignore columns that exist more than once.
    			throw new Exception("The following query is returning more than one field with the same key, " + _key + ": " + commandText); // command.CommandText
    		}
    
    		_result.Add(_key, _value);
    	}
    
    	T _object = new ModelBinder().BindModel<T>(_result);
    
    	if (_object != null)
    	{
    		results.Add((T)_object);
    	}        
    }
