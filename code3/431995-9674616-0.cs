    public class SomeEntity
    {
        public int Id { get; set; }
        public int UserAId { get; set; }
        [InverseProperty("SomeEntitiesA")]
        public virtual User UserA { get; set; }
        public int UserBId { get; set; }
        [InverseProperty("SomeEntitiesB")]
        public virtual User UserB { get; set; }
    }
