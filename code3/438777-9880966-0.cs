    var allPublicInterfacesFromLibrary = typeof(AnyLibraryType)
        .Assembly.GetTypes()
		.Where(t => t.IsInterface && t.IsPublic);
	foreach (var libraryInterface in allPublicInterfacesFromLibrary)
	{
		var local = libraryInterface; //to prevent closure
		applicationContainer.Register(
			Component.For(libraryInterface)
            //delegate resolving
			.UsingFactoryMethod(k => libraryContainer.Resolve(local)) 
            //delegate lifetime management
			.LifestyleTransient() 
		);
	}
