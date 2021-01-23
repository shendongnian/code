    public class EstablishmentNode : Entity
    {
        public int AncestorId { get; set; }
        public virtual Establishment Ancestor { get; set; }
        public int OffspringId { get; set; }
        public virtual Establishment Offspring { get; set; }
        public int Separation { get; set; }
    }
    public class Establishment : Entity
    {
        ...
        public virtual ICollection<EstablishmentNode> Ancestors { get; set; }
        public virtual ICollection<EstablishmentNode> Offspring { get; set; }
    }
