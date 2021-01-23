    public class Establishment : Entity
    {
        public string Name { get; set; }
        public virtual Establishment Parent { get; set; }
        public virtual ICollection<Establishment> Children { get; set; }
        ...
    }
