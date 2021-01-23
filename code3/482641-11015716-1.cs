    if (_openedViews.ContainsKey(key) == false)
    {
       _openedViews.Add(key, null);
       _openedViews[key] = ServiceRegistry.GetService<IShellService>().GetView(key);
    }
