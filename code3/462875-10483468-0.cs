    var yourIPlugin = typeof(IPlugin);
    foreach (Type t in assembly.GetTypes())
    {
        if (yourIPlugin.IsAssignableFrom(t))
		{
                T p = (T)Activator.CreateInstance(t);
                if (!this.Plugins.Select(sp => sp.Name).Contains(p.Name))
                    this.Plugins.Add(p);
		}
	}
