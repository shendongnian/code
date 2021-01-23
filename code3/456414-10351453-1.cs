    void Bootstrap()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(TestMargin).Assembly));
      _container = new CompositionContainer(catalog);
  
     //Fill the imports of this object
     try
     {
        var objectToSatisfy = this;
        // var objectToSatifsy = new SomeOtherObjectWithImports();
  
        this._container.ComposeParts(objectToSatisfy);
     }
     catch (CompositionException compositionException)
     {
        System.Diagnostics.Trace.WriteLine(compositionException.Message);
     }
    }
