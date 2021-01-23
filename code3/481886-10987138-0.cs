      public void AssembleCalculatorComponents() {
         try {
            var asmCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
         // OR
            var asmCatalog = new AssemblyCatalog(typeof(...).Assembly); // replace (...) with (object's type)
            var aggregateCatalog = new AggregateCatalog(asmCatalog);
            var container = new CompositionContainer(catalog);
            // assuming this class has the member(s) to be composed.
            container.ComposeParts(this);
         } catch (Exception ex) {
            throw ex;
         }
      }
