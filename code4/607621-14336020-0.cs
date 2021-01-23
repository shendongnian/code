    public class A
    {
        public virtual Guid AId { get; set; }
        public virtual string Name { get; set; }
        public virtual B BObject { get; set; }
        public virtual Guid BId { get; set; } // virtual "navigational" property
    }
