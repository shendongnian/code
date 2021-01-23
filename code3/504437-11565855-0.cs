    public class Establishment : Entity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public virtual Establishment Parent { get; set; }
        public virtual ICollection<Establishment> Children { get; set; }
        ...
    }
