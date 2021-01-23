    public class BusinessModelMenuDto
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public Guid? ParentID { get; set; }
        public string TextToDisplay { get; set; }
        public string ImageSource { get; set; }
        [Include]
        [Association("SubItems", "ID", "ParentID")]
        public IEnumerable<BusinessModelMenuDto> SubMenuItems { get; set; }
    }
