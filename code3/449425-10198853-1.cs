    public class MyTreeViewItem
    {
        public string Name { get; private set; }
        public ObservableCollection<MyTreeViewItem> SomeItems { get; private set; }
        public MyTreeViewItem(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            this.SomeItems = new ObservableCollection<MyTreeViewItem>();
            this.Name = name;
        }
    }
