    var propertyMapping = new Dictionary<string, PropertyInfo>();
    var efPersonType = typeof(Person);
    var sqlitePersonType = typeof(SQLLitePerson);
    
    foreach (var prop in sqlitePersonType.GetProperties())
    {
    	var efProp = efPersonType.GetProperties()
    							 .FirstOrDefault(p => p.Name.ToLower() == prop.Name.ToLower());
    	if (efProp != null)
    	{
    		propertyMapping.Add(prop.Name, efProp);
    	}
    }
    
    foreach(var person in SQLiteDB.persons)
    {
    	Person thenewperson = new Person();
    	foreach (var prop in sqlitePersonType.GetProperties())
    	{
    		PropertyInfo newProp;
    		if (propertyMapping.TryGetValue(prop.Name, out newProp))
    		{
    			newProp.SetValue(thenewperson, prop.GetValue(person, null), null);
    		}
    	}
    	SQlserverDB.Persons.AddorUpdate(thenewperson);
    }
