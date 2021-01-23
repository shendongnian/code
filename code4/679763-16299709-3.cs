     // have your auto registration
     container.RegisterTypes(
       AllClasses.FromLoadedAssemblies(),  //uses reflection
       WithMappings.FromMatchingInterface, //Matches Interfaces to implementations by name
       WithName.Default);
     // and override it when necessary
     container.LoadConfiguration();
