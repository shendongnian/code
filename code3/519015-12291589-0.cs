    protected override void ConfigureAggregateCatalog()
            {
                base.ConfigureAggregateCatalog();
    
                // Add this assembly to the catalog.
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
                
                // Add the FooService assembly
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(FooService).Assembly));
            }
