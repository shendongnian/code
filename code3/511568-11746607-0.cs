		string prefix = "p22";
		IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes();
		Type baseClass = typeof(foo);
		Type foundType = types.Where(
			t => t.Name.StartsWith( prefix ) &&
				t.IsSubclassOf( baseClass )
				).SingleOrDefault();
		foo myClass = (foo)Activator.CreateInstance( foundType );
                //Do Stuff with myClass 
	}
