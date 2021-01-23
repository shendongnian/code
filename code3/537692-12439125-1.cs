    public class MyEntity
    {
        public MyEntity(int entityId, MyEntity parent)
        {
            this.Children = new List<MyEntity>();
            this.EntityId = entityId;
            this.Parent = parent;
            this.Parent.Children.Add(this);
        }
        public int EntityId { get; set; }
        public MyEntity Parent { get; set; }
        public List<MyEntity> Children { get; set; }
    }
