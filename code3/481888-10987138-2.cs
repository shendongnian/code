      public void AssembleCalculatorComponents() {
         try {
            var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
         // OR
            asmCatalog = new AssemblyCatalog(typeof(TObject).Assembly); // replace TObject with object's actual type
            var aggregateCatalog = new AggregateCatalog(asmCatalog);
            // 
            AddDirectoryCatalogs(aggregateCatalog.Catalogs));
            var container = new CompositionContainer(catalog);
            // assuming this class has the member(s) to be composed.
            container.ComposeParts(this);
         } catch (Exception ex) {
            throw ex;
         }
      } 
