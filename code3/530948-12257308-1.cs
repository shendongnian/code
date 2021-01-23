    public interface IQueryPlugin
    {
        string PluginCategory { get; }
        string Name { get; }
        string Version { get; }
        string Author { get; }
        bool IsTypeAcceptable(TheTypeType type); // get it, thetypetype? hahaha
    }
    private void QueryPlugins(List<string> val, bool sensitive)
    {
        foreach (string tType in val) //Cycle through a List<string>
        {
            foreach (var plugin in this.QPlugins) //Cycle through all query plugins
            {
                if (plugin.IsTypeAcceptable(tType))
                    //process it here
            }
        }
    }
