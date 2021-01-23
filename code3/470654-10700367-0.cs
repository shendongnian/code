    [Table("abmt_Dynamic_Menu")]
    public class DynamicMenu
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int dmn_id { get; set; }
        public string dmn_code { get; set; }
        public string dnm_parent_code { get; set; }
        public string dnm_title { get; set; }
        public string dnm_title_en { get; set; }
        public int dnm_order { get; set; }
    }
