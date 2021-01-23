    // using System;
    // using System.Diagnostics;
    // using System.Linq;
    ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
    Assembly entryAssembly = AppDomain.CurrentDomain.GetAssemblies()
                             .Single(assembly => assembly.Location == mainModule.FileName);
