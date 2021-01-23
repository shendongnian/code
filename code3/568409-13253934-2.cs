    using System;
    using System.ComponentModel.Composition;
    using MEFContract;
    
    namespace Plugin
    {
        [Export(typeof(IPlugin))]
        public class Plugin : IPlugin
        {
            public void DoPluginStuff()
            {
                Console.WriteLine("Doing my thing!");
            }
        }
    }
    
