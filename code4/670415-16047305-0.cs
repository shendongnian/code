    //in your Metadata you should have bool FireOnSave
    public class Sales
    {
        IEnumerable<Lazy<T, TMetadata>> myPlugins;
        private static CompositionContainer _container;
        static Sales()
        {
            var catalog = new AggregateCatalog();
            var d = new DirectoryInfo(".\\");
            catalog.Catalogs.Add(new DirectoryCatalog(d.FullName));
            _container = new CompositionContainer(catalog);
        }
    
        void ImportPlugins()
        {
             myPlugins = _container.GetExports<T, TMetadata>();
        }
    
        public void Save()
        {
            //do your saving work here
            fire_plugins();
        }
    
        private void fire_plugins()
        {
            foreach (var m in myPlugins)
            {
                if (m.Metadata.FireOnSave)
                    m.Value.Invoke();
            }
        }
    }
