    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using MEFContract;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var prgm = new Program();
    
                // Search the "Plugins" directory for assemblies that match the imports.
                var catalog = new DirectoryCatalog("Plugins");
                using (var container = new CompositionContainer(catalog))
                {
                    // Match Imports in "prgm" object with corresponding exports in all catalogs in the container
                    container.ComposeParts(prgm);
                }
    
                prgm.DoStuff();
    
                Console.Read();
            }
    
            private void DoStuff()
            {
                foreach (var plugin in Plugins)
                    plugin.DoPluginStuff();
            }
    
            [ImportMany] // This is a signal to the MEF framework to load all matching exported assemblies.
            private IEnumerable<IPlugin> Plugins { get; set; }
        }
    }
    
