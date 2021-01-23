    public class MainContainer
    {
        private CompositionContainer _container;
        [ImportMany]
        public IEnumerable<IPlugin> Plugins;
        public AdapterProvider(string pluginpath)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(pluginpath));
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }
    }
