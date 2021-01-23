    class ListItem
    {
        public List<ListItem> Parent { get; set; }
        public ListItem(List<ListItem> parent)
        {
            Parent = parent;
        }
    }
    ListItem listItem = new ListItem(abc);
    abc.Add(listItem);
    // Get collection from item.
    List<T> def = listItem.Parent;
