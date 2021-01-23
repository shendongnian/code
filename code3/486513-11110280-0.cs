    public class EntityTabItem : TabItem
    {
        private Entity _myEntity;
        public Entity MyEntity
        {
            get { return _myEntity; }
            set
            {
                _myEntity = value;
                DataContext = value;
            }
        }
    
        public EntityTabItem(string path)
        {
            this.MyEntity = new Entity(path);
        }
    
        static EntityTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EntityTabItem), new FrameworkPropertyMetadata(typeof(EntityTabItem)));
        }
    }
