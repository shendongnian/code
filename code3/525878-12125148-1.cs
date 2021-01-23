    public abstract class ModelBase
    {
        public DateTime CreateDate { get; private set; }
        public Guid Guid { get; private set; }
        public ModelBase()
        {
            Guid = Guid.NewGuid();
            DateTime = DateTime.Now;
        }
    }
    public User : ModelBase
    {
        public User()
            : base()
        {
        }
        public User(string name)
            : base()
        {
            Name = name
        }
        public string Name { get; set; } 
    }
