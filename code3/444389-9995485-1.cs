    public abstract class X
    {
        public virtual List<X> ChildItems { get; set; }
        public virtual X ParentItem { get; set; }
        // Method for traversing from top to bottom
        public void Traverse(Action<X> action)
        {
            action(this);
            foreach (X item in ChildItems) {
                item.Traverse(action);
            }
        }
        // Get the root (the top) of the tree starting at any item.
        public X GetRootItem()
        {
            X root = this;
            while (root.ParentItem != null) {
                root = root.ParentItem;
            }
            return root;
        }
    }
