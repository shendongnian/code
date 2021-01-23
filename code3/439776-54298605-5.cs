    public List<YourClassOfItemInTheGrid> SelectedItems { get; set; }  = new List<YourClassOfItemInTheGrid>();
    public ICommand SelectedItemsCommand
    {
        get
        {
            return new GetSelectedItemsCommand(list =>
            {
                SelectedItems.Clear();
                IList items = (IList)list;
                IEnumerable<YourClassOfItemInTheGrid> collection = items.Cast<YourClassOfItemInTheGrid>();
                SelectedItems = collection.ToList();
            });
        }
    }
