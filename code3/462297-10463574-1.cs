    public class NestedCollectionRootViewModel
    {
        public NestedCollectionRootViewModel()
        {
            Items =
                new ObservableCollection<NestedCollectionChildViewModel>
                    {
                        new NestedCollectionChildViewModel
                            {
                                Title = "Item 1",
                                Items =
                                    new ObservableCollection<NestedCollectionItem>
                                        {
                                            new NestedCollectionItem {Title = "One"},
                                            new NestedCollectionItem {Title = "Two"},
                                            new NestedCollectionItem {Title = "Three"},
                                            new NestedCollectionItem {Title = "Four"},
                                        }
                            },
                        new NestedCollectionChildViewModel
                            {
                                Title = "Item 2",
                                Items =
                                    new ObservableCollection<NestedCollectionItem>
                                        {
                                            new NestedCollectionItem {Title = "Five"},
                                            new NestedCollectionItem {Title = "Six"},
                                        }
                            },
                    };
        }
        public ObservableCollection<NestedCollectionChildViewModel> Items 
           { get; private set; }
    }
    public class NestedCollectionChildViewModel
    {
        public string Title { get; set; }
        public ObservableCollection<NestedCollectionItem> Items { get; set; }
    }
    public class NestedCollectionItem
    {
        public string Title { get; set; }
        // ... etc
    }
