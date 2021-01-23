     public class GalleryCategory
        {
            [Key]
            public int CategoryID { get; set; }
            public string Name { get; set; }
            public int? ParentID { get; set; }
            [ForeignKey("ParentID")]
            public virtual List<GalleryCategory> Subcategories { get; set; }
        }
