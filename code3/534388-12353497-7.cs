    var propertyMapping = new Dictionary<PropertyInfo, PropertyInfo>();
    var efPersonType = typeof(Person);
    var sqlitePersonType = typeof(SQLLitePerson);
    
    foreach (var prop in sqlitePersonType.GetProperties())
    {
    	var efProp = efPersonType.GetProperties()
    							 .FirstOrDefault(p => p.Name.ToLower() == prop.Name.ToLower());
    	if (efProp != null)
    	{
    		propertyMapping.Add(prop, efProp);
    	}
    }
    
    foreach (var person in SQLiteDB.persons)
    {
    	Person thenewperson = new Person();
    	foreach (var i in propertyMapping)
    	{
    		i.Value.SetValue(thenewperson, i.Key.GetValue(person, null), null);
    	}
    	SQlserverDB.Persons.AddorUpdate(thenewperson);
    }
