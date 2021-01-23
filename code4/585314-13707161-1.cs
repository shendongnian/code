        protected override void AddPluginsLoaders(Cirrious.MvvmCross.Platform.MvxLoaderPluginRegistry loaders)
        {
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Sqlite.WinRT.Plugin>();
            base.AddPluginsLoaders(loaders);
        }
     
