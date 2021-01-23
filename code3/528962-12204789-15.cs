    var plugins = Plugins.OrderBy(p => p.Value.ViewModel.HeaderText);
    foreach (var app in plugins)
    {
        // Take the View from the Plugin and Merge it with,
        // our Applications Resource Dictionary.
        Application.Current.Resources.MergedDictionaries.Add(app.Value.View)
        // THen add the ViewModel of our plugin to our collection of ViewModels.
        var vm = app.Value.ViewModel;
        Workspaces.Add(vm);
    }
