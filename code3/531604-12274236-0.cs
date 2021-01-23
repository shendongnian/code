    public class ImageMeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ImageFile> Files { get; set; } 
    }
