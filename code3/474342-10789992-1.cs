    class PluginHost
    {
        public static IPlugin GetPlugin()
        {
            Assembly asmbly = Assembly.LoadFrom("YourPlugin.dll");
            Type objectType = asmbly.GetType("YourPlugin");
            return (IPlugin)Activator.CreateInstance(objectType);
        }
    }
