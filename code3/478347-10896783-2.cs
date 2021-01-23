    public class Item
    {
        public Item(int id, int? parentId)
        {
            Id = id;
            ParentId = parentId;
        }
        public int Id { get; private set; }
        public int? ParentId { get; private set; }
        public List<Item> SubItems  { get; set; }
        private Item _parent;
        public Item Parent 
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                    _parent.SubItems.Remove(this);
                _parent = value;
                if (_parent != null)
                    _parent.SubItems.Add(this);
            }
        }
    }
