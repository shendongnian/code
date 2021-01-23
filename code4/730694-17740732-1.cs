    [Table]
    public class DirectoryItem 
    {
        [Column(IsVersion=true)]
        private Binary version;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int primaryKey;
        private System.Nullable<int> parentId;
        [Column(Storage = "parentId", DbType="Int")]
        public System.Nullable<int> ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.SetProperty(ref this.parentId, value);
            }
        }
        private EntityRef<DirectoryItem > parent;
        [Association(Name = "DirectoryItem_parent", Storage = "parent", ThisKey = "ParentId", OtherKey = "primaryKey", IsForeignKey = true)]
        public DirectoryItem Parent
        {
            get
            {
                return parent.Entity;
            }
            set
            {
                if (this.PropertyChanging != null)
                    PropertyChanging(this, new PropertyChangingEventArgs("Parent"));
                parent.Entity = value;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Parent"));
            }
        }
        private EntitySet<DirectoryItem > children;
        [Association(Name = "DirectoryItem_DirectoryItem", Storage = "Children", ThisKey = "primaryKey", OtherKey = "ParentId")]
        public EntitySet<DirectoryItem > Children
        {
            get
            {
                if (children == null)
                    children = new EntitySet<DirectoryItem >();
                return children;
            }
            set
            {
                if (this.PropertyChanging != null)
                    PropertyChanging(this, new PropertyChangingEventArgs("Children"));
                if (children == null)
                    children = new EntitySet<DirectoryItem >();
                this.children.Assign(value);
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Children"));
            }
        }
    }
