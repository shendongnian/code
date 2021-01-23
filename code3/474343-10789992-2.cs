    class PluginUser
    {
        public bool GetTrueValueFromPlugin()
        {
            IPlugin pluginObj = PluginHost.GetPlugin();
            pluginObj.MethodReturningTrue();
        }
    }
