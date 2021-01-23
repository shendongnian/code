    var plugins = Plugins.OrderBy(p => p.Value.PluginWeight).ThenBy(p => p.Value.ViewModel.HeaderText);
    foreach (var app in plugins)
    {
        Application.Current.Resources.MergedDictionaries.Add(app.Value.View)
        var vm = app.Value.ViewModel;
        Workspaces.Add(vm);
    }
