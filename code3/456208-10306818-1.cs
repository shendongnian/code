    var assembly = Assembly.Load(AssemblyName.GetAssemblyName(fileFullName));
    foreach (Type t in assembly.GetTypes())
    {
      if (!typeof(IMyPluginInterface).IsAssignableFrom(t)) continue;
      var instance = Activator.CreateInstance(t) as IMyPluginInterface;
      //Voila, you have lazy loaded the plugin dll and hooked the plugin class to your code
    }
