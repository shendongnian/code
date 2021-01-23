    public class TestEntity
    {
        public int Id { get; set; }    
        public virtual TestEntity2 SubEntity2 { get; set; }
        public virtual TestEntity3 SubEntity3 { get; set; }    
        public virtual ICollection<SubEntity4> SubEntities { get; set; }
    }
