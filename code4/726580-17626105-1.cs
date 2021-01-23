    using System;
    using Microsoft.Xrm.Sdk;
    
    public class PluginStepRegistrationPlugin : IPlugin
    {
        static PluginStepRegistrationPlugin()
        {
            AssemblyLoader.RegisterAssemblyLoader();
        }
    
        public void Execute(IServiceProvider serviceProvider)
        {
            //...
        }
    }
