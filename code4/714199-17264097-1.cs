    public class EntityB
    {
        public int ID { get; set; }
        public Nullable<int> PreferredEntityAID { get; set; }
        [ForeignKey("PreferredEntityAID")]
        public virtual EntityA PreferredEntityA { get; set; }
        [InverseProperty("EntityB")] // <- Navigation property name in EntityA
        public virtual ICollection<EntityA> EntityAs { get; set; }
    }
