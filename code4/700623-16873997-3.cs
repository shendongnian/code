    protected SelectableItemViewModel(T item)
    {
        Item = item;
        SelectItemCommand = new RelayCommand(SelectItem);
    }
    public T Item { get; private set; }
    public RelayCommand SelectItemCommand { get; private set; }
    protected override void SelectItem()
    {
        base.SelectItem();
        Navigate(Item.DetailPageName, Item);
    }
