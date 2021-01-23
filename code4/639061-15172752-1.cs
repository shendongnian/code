       [Table("Box")]
    public class Box
    {
        [Required]
        [Key]
        [Column("BoxId")]
        public virtual int BoxId { get; set; }
        [Column("Name")]
        public virtual string Name { get; set; }
        [Column("ParentBoxID")]
        public virtual int? MyParentBoxId { get; set; }
        [ForeignKey("MyParentBoxId")]
        public virtual Box Parent { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Box> Boxes { get; set; }
       
    }
