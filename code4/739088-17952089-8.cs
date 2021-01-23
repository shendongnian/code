    public class TreeViewModel: PropertyChangedBase
    {
        public int Value { get; set; }
        public ObservableCollection<TreeViewModel> Items { get; set; }
        public CollectionView ItemsView { get; set; }
        public TreeViewModel(int value)
        {
            Items = new ObservableCollection<TreeViewModel>();
            ItemsView = new ListCollectionView(Items)
                {
                    SortDescriptions =
                        {
                            new SortDescription("Value",ListSortDirection.Ascending)
                        }
                };
            Value = value;
        }
    }
