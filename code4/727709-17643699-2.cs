    static void Main(string[] args)
    {
        using (var catalog = // configure composable part catalog here, read MEF docs to find best way for you)
        using (var container = new CompositionContainer(catalog))
        {
            var database = container.GetExportedValue<IDatabase>();
            // you're working with IDatabase and IDealerRepository here,
            // there's no direct access to the particular implementation classes 
            database.Dealer.DealerProifle_Lookup("Best Dealer Cars Buy");
            // ...
        }
    }
