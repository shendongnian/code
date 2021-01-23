    public class A
    {
        [Key]
        public int ID { get; set; }
        public string Property { get; set; }
    }
    [Table("B")]
    public class B : A
    {
        // more properties...
        // 1:Many with A
        public ICollection<A> CollectionA { get; set; }
    }
    [Table("C")]
    public class C : A
    {
        // more properties...
        // 1:Many with A
        public ICollection<A> CollectionA { get; set; }
    }
    [Table("D")]
    public class D : A
    {
        // more properties...
        // 1:Many with A
        public ICollection<A> CollectionA { get; set; }
    }
