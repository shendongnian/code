    [ComplexType]
    public class Region
    {
        [Column("RegionId")]
        public virtual int Id { get; set; }
        [NotMapped]
        public virtual string Code { get; set; }
    }
