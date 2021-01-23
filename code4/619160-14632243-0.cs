    [Table("CATEGORY")]
    public class Kategori
    {
        [Key]
        public Guid CATEGORY_ID { get; set; }
        [MaxLength(100)]
        public string CATEGORY { get; set; }
        [MaxLength(100)]
        public string CATEGORY_TR { get; set; }
        [ForeignKey("ANA_CATEGORY_ID")]
        public virtual AnaKategori AnaKategori { get; set; }
    }
