    var type = typeof(Base);
    var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
    		.SelectMany(s => s.GetTypes())
    		.Where(p => type.IsAssignableFrom(p));
    
    var jsonProviderClass = typeof(JsonContentProvider<>);
    var xmlProviderClass = typeof(XmlContentProvider<>);
    
        foreach (var t in types) {
        	Type[] typeArgs = { t };
        	// get XML provider
        	var xmlGenericProvider = xmlProviderClass.MakeGenericType(typeArgs);
        	object xmlProvider = Activator.CreateInstance(xmlGenericProvider);
        	// get JSON provider
        	var jsonGenericProvider = jsonProviderClass.MakeGenericType(typeArgs);
        	object jsonProvider = Activator.CreateInstance(jsonGenericProvider);
        	// methods to run
        	MethodInfo xmlMethod = xmlGenericProvider.GetMethod("GetContent", new Type[] { typeof(string) });
        	MethodInfo jsonMethod = jsonGenericProvider.GetMethod("Update");
        	// get content from XML provider
        	var result = xmlMethod.Invoke(xmlProvider, new object[] { string.Empty });
        	// enumerate XML content items
        	foreach (var item in ((IEnumerable)result)) {
        		// update them via JSON provider
        		object[] parametersArray = new object[] { item };
        		var update = jsonMethod.Invoke(jsonProvider, parametersArray);
        	}
        }
