    using System;
    using Microsoft.Xrm.Sdk;
    
    public class MyPlugin : IPlugin
    {
        static MyPlugin()
        {
            AssemblyLoader.RegisterAssemblyLoader();
        }
    
        public void Execute(IServiceProvider serviceProvider)
        {
            //...
        }
    }
