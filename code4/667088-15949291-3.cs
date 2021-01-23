    public interface IHaveSystemViewModel {
        SystemViewModel system { get; set; }
    }
    var model = viewModel as IHaveSystemViewModel;
    if (model != null) {
        // again, you need to make sure you actually have a reference here...
        var system = model.system ?? (model.system = new SystemViewModel());
        system.isReadOnly = false; // or true
    }
