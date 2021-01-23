        protected override IMvxPluginManager CreatePluginManager()
        {
            var toReturn = new MvxLoaderBasedPluginManager();
            var sharedRegistry = new MvxLoaderPluginRegistry(".WindowsPhone",toReturn.Loaders);
            sharedRegistry.AddConventionBasedPlugin<SharedP1>();
            sharedRegistry.AddConventionBasedPlugin<SharedP1>();
            sharedRegistry.AddConventionBasedPlugin<SharedP3>();
            var wp7Registry = new MvxLoaderPluginRegistry(".WP7",toReturn.Loaders);
            wp7Registry.AddConventionBasedPlugin<WP7P1>();
            wp7Registry.AddConventionBasedPlugin<WP7P2>();
            return toReturn;
        }
