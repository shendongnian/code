    class PluginWithMetaData
    {
      public PluginWithMetaData(Foo plugin)
      {
         Plugin = plugin;
         MD5 = PluginFunctions.GetMD5(plugin);
      }
    
      public Foo Plugin { get; private set; }
      public string MD5 { get; private set; } 
    }
