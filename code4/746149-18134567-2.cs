    public partial class Item
     ...
        public virtual int? ParentId { get; set; }
        public virtual Item Parent { get; set; }
        public virtual ICollection<Item> Children { get; set; }
    }
