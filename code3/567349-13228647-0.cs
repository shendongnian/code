    var catalog = new AggregateCatalog();
    //Add all the parts found in all assemblies in
    //the same directory as the executing program
    catalog.Catalogs.Add(
                    new DirectoryCatalog(
                        Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location
                        )
                    )
                );
             
    var container = new CompositionContainer(catalog);
    container.ComposeParts(container);
    
    // Use the container to get a value for myinterface
    myinterface = container.GetExportedValue<Contracts.IInput>();
    Console.WriteLine(myinterface.IsValid());
