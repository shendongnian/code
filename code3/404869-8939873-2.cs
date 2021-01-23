    // Container that the TreeView control needs
    public class CategoryHierarchyItem : IHierarchyData {
        // Internal field to store your data
        private Category _Item;
        // the constructor used to instantiate the class
        public CategoryHierarchyItem(Category input) {
            this._Item = input;
        }
        // returns another tree with children if any
        public IHierarchicalEnumerable GetChildren() {
            if (_Item.Children != null)
                return new CategoryTree(_Item.Children);
            return new CategoryTree();
        }
        // The boolean value indicating weather this is the deepest level of your
        // categories
        public Boolean HasChildren {
            get { return _Item.Children != null; }
        }
        // Actual data item
        public Object Item {
            get { return _Item; }
        }
        // This is the path. 
        // Construct it as you think is necessary.
        // Here the format is the same as in namespaces of C#
        public String Path {
            get {
                var sb = new StringBuilder();
                var current = _Item;
                sb.Append(_Item.CategoryName);
                while (current != null) {
                    sb.Insert(0, ".");
                    sb.Insert(0, current.CategoryName);
                    current = current.Parent;
                }
                return sb.ToString();
            }
        }
        public String Type {
            get { return "Category"; }
        }
        // returns the parent of the current item
        public IHierarchyData GetParent() {
            if (_Item.Parent != null)
                return new CategoryHierarchyItem(_Item.Parent);
            return null;
        }
    }
