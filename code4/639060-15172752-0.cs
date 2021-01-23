    public class Box
    {
        [Required]
        [Key]
        int BoxId { get; set; }
        string BoxName { get; set; }
        [ForeignKey("ParentBox")]
        int ParentBoxId { get; set; }
        Box ParentBox { get; set; }
        List<Box> Boxes {get; set;}
    }
