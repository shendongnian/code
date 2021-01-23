    // create and initialize unity container once somewhere in startup code.
    var сontainer = new UnityContainer();
    container.LoadConfiguration(); // load unity configuration from application xml config 
    // then use container to resolve dependencies.
    if (CountryCodeSaysToUseDb())
       return container.Resolve<MyAssembly.ILog>("sql");
    if (ContryCodeSaysToUseFile())
       return container.Resolve<MyAssembly.ILog>("file");
