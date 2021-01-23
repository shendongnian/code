    private void ProcessAllStrings(Type objectType, HashSet<Type> typesChecked)
    {
    	if (typesChecked == null)
    		typesChecked = new HashSet<Type>();
    		
    	if (typesChecked.Contains(objectType))
    		return;
    	
    	typesChecked.Add(objectType);
    	
    	BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    	
    	foreach (PropertyInfo p in objectType.GetProperties(flags))
    	{
    		Type currentNodeType = p.PropertyType;
    		if (currentNodeType == typeof (String))
    		{
    			//here I do my custom string handling. Code deleted
    			Console.WriteLine("Found String Property: " + currentNodeType.FullName + " -> " + p.Name);
    		}
    			//if non primitive and non string then recurse. (nested/inner class instances)
    			// see http://stackoverflow.com/questions/4444908/detecting-native-objects-with-reflection
    		else if (currentNodeType != typeof (object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
    		{
    			//I need to get the reference to this property which happens to be a nested class
    			//but propertyInfo only provides GetValue(). No GetReference available..
    			ProcessAllStrings(currentNodeType, typesChecked);
    		}
    	}
    }
