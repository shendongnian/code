    foreach(string pluginassemblypath in pluginspaths)
    { 
        //Each pluginassemblypath (as it says..) is the full path to the assembly
        helperDomain<IPluginClass> isoDomain = 
            helperDomain<IPluginClass>(pluginassemblypath, 
                 pluginassemblypath + ".config", 
                 System.IO.Path.GetFileName(pluginassemblypath) + ".domain");
        if (isoDomain.LoadOK)
        {
           //We can access instance of the class (.InstancedObject)
           Console.WriteLine("Plugin loaded..." + isoDomain.InstancedObject.GetType().Name);
        }
        else
        {
           //Something happened...
           Console.WriteLine("There was en error loading plugin " + 
                pluginassemblypath + " - " + helperDomain.LoadingErrors);
        }
    }
                
