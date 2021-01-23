    var assembly = Assembly.GetExecutingAssembly(); // Replace with the assembly you want to resolve for.
    var exports = assembly.ExportedTypes;
    var viewTypes = exports.Where(t => t.GetInterface(typeof(IView).FullName) != null);
                
    foreach (var viewType in viewTypes)
    {
        var viewModelType = assembly.GetType(viewType.FullName.Replace("View", "ViewModel"));
        var viewModel = container.Resolve(viewModelType);
        var view = container.Resolve(viewType);
        view.ShowDialog();
    }
