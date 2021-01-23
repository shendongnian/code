    public class Box
    {
        [Required]
        [Key]
        public int BoxId { get; set; }
    
        public string BoxName { get; set; }
    
        public int ParentBoxId { get; set; }
    
        // The foreign key for the Box that points at ParentBox.BoxId  (the [Key])
        [ForeignKey("ParentBoxId")]
        public Box ParentBox { get; set; }
    
        // The foreign key for the Boxes that point at this.BoxId (the [Key])
        [ForeignKey("ParentBoxId")]
        public virtual ICollection<Box> Boxes {get; set;}
    }
