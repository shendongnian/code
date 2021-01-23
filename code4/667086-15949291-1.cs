    public interface IHaveSystemViewModel {
        SystemViewModel system { get; set; }
    }
    var model = viewModel as IHaveSystemViewModel;
    if (model != null) {
        model.system.isReadOnly = false; // or true
    }
