    using System;
    using System.Reflection;
    using System.Resources;
    
    // Gets a reference to the current assembly.
    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;            
    // Creates the ResourceManager.
    ResourceManager resourceManager = new ResourceManager(String.Format("{0}.TextResources", assemblyName), Assembly.GetExecutingAssembly());
    // Retrieves resource and displays it.
    string textFileContents = resourceManager.GetString("TableList");
    Console.Write(textFileContents);
