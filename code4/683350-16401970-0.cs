    public ItemSelectorView(ItemSelectorViewModel itemSelectorViewModel)
    {
        InitializeComponent();
        if (!Designer.IsInDesignMode())
        {
            DataContext = itemSelectorViewModel;
        }
    }
