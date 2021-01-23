    public class Server
    {
        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        public IFASTAdapter FirstAdapter { get; set; }
        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        public IFASTAdapter SecondAdapter { get; set; }
        // Other adapters ...
        public void Compose()
        {
            var catalog = new AggregateCatalog();
            var pluginsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            foreach (string d in Directory.GetDirectories(pluginsDir))
            {
                catalog.Catalogs.Add(new DirectoryCatalog(d));
            }
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
