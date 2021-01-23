    [Table("artikeldaten_preise")]
    public class ArticlePrice : ClassicEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("einheit")]
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        [Column("preisliste")]
        public int PricelistId { get; set; }
        [ForeignKey("PricelistId")]
        public virtual Pricelist Pricelist { get; set; }
        [Column("artikel")]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
        [Column("preis")]
        public double Price { get; set; }
    }
