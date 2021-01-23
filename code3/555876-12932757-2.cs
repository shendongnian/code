        protected override void AddPluginsLoaders(Cirrious.MvvmCross.Platform.MvxLoaderPluginRegistry loaders)
        {
            loaders.AddConventionalPlugin<AlphaPage.MvvmCross.Plugins.Mega.WindowsPhone.Plugin>();
            base.AddPluginsLoaders(loaders);
        }
