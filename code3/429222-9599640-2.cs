    // update MyProcessorLibrary with this property
    [Dependency]
    public IEnumerable<IMyProcessor> MyProcessingThing
    {
     get { return _processors; }
     set { _processors = value; }
    }
     //then inject the library class like this
     var lib = myContainer.Resolve<MyProcessorLibrary>();
     myProcessorRepository(lib)
    
