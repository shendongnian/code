    protected SelectableItemViewModel(T item)
        : base(item)
    {
        SelectItemCommand = new RelayCommand(SelectItem);
    }
    public RelayCommand SelectItemCommand { get; private set; }
    protected override void SelectItem()
    {
        base.SelectItem();
        Navigate("/AlbumPage.xaml", this);
    }
