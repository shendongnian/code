    void LoadPlugins(Assembly a)
    {
        var plugins = 
            a.GetTypes()
            .Where(t => typeof(IPlugin).IsAssignableFrom(t))
            .Select(t => (IPlugin)Activator.CreateInstance(t))
            .ToList();
         Plugins.AddRange(plugins);
         foreach (var p in plugins)
         {
             p.Load(Context);
         }
    }
