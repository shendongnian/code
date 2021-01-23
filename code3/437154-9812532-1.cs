    public class TreeViewDblClickViewModel
    {
        public TreeViewDblClickViewModel()
        {
            Items = new List<TreeViewDblClickItem>
                        {
                            new TreeViewDblClickItem{ Name = "One"},
                            new TreeViewDblClickItem{ Name = "Two"},
                            new TreeViewDblClickItem{ Name = "Thee"},
                            new TreeViewDblClickItem{ Name = "Four"},
                        };
        }
        public IList<TreeViewDblClickItem> Items { get; private set; }
    }
    public class TreeViewDblClickItem
    {
        public TreeViewDblClickItem()
        {
            DoubleClickCommand = new ActionCommand(DoubleClick);
        }
        public string Name { get; set; }
        private void DoubleClick()
        {
            Debug.WriteLine("Double click");
        }
        public ICommand DoubleClickCommand { get; private set; }
    }
