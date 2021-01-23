    // this.FactoryMethod is an external dependency passed into this class
    // through constructor or property injection assume that it is not null
    // but there is no guarantee that it will return a non-null reference.
    Func<IModel> FactoryMethod;
    
    public IModel GetPopulatedModel(int state, FileInfo someFile)
    {       
       // Argument validation omitted for brevity...
    
       // This operation could return null.
       var model = this.FactoryMethod()
       if (model == null)
       {
          this.Logger.Write("Factory method failed to produce a value.");
          return null;
       }
    
       // Safe to assign to properties at this point.
       model.Priority = state;
       model.File = someFile;
       return model;
    }
