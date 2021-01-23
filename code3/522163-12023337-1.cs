    public abstract class CollectionColumnBase
    {
        private string _name;
        private string _displayName;
        
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        
        public string DisplayName {
            get { return _displayName; }
            set { _displayName = value; }
        }
        
        public abstract object GetItemAt(int index);
    }
    public class CollectionColumn<T> : CollectionColumnBase
    {
        private List<T> data = new List<T>();
        public overrides object GetItemAt(int index)
        {
            return data[index];
        }
        public List<T> Items
        {
            get { return data; }
            set { data = value; }
        }
    }
    public class ColumnCollection
    {
        public int Id { get; set; }
        public string ContainerName { get; set; }
        
        private List<CollectionColumnBase> _columns;
        public List<CollectionColumnBase> Columns {
            get { return _columns; }
            set { _columns = value; }
        }
    }
