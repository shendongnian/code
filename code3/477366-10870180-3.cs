    public class Foo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        public virtual ICollection<FooBar> FooBars { get; set; }
    }
    public class Bar
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Foo> Foos { get; set; }
        public virtual ICollection<FooBar> FooBars { get; set; }
    }
    public class FooBar
    {
        [Key, Column(Order = 0)]
        public int FooId { get; set; }
        [Key, Column(Order = 1)]
        public int BarId { get; set; }
        public virtual Foo Foo { get; set; }
        public virtual Bar Bar { get; set; }
        public bool IsRead { get; set; }
    }
