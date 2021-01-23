    public ObservableCollection<ViewModel> CreateNamesViewModels()
    {
        var models = Service.Request();
        return new ObservableCollection(models.Select(m => new ViewModel(m)));
    }
