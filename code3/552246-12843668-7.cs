    public class SimplePluginManager : IMvxPluginManager
    {
        public SimplePluginManager()
        {
            // load the plugins your app needs here!
            Cirrious.MvvmCross.Plugins.Visibility.Wp7.Plugin.Load();
            Cirrious.MvvmCross.Plugins.Color.WindowsPhone.Plugin.Load();
        }
        public bool IsPluginLoaded<T>() where T : IMvxPluginLoader
        {
            return true;
        }
        public void EnsureLoaded<T>() where T : IMvxPluginLoader
        {
        }
    }
