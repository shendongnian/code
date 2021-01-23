    public class MetaData
    {
        public int Id { get; set; }
        public string SomeProperty { get; set; }
        public ICollection<SomeEntity> SomeEntities { get; set; }
        public ICollection<CompletelyDifferentEntity>
            CompletelyDifferentEntities { get; set; }
    }
