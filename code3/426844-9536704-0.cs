    class PlugginsList : List<Type>
    {
      public void Add<T>()
        where T : IPlugin
      {
        Add(typeof(T));
      }
    }
    
    var plugginList = new PlugginsList();
    plugginList.Add<PluginA>() --> OK
    plugginList.Add<PluginB>() --> OK
    plugginList.Add<PluginC>() --> will fail
