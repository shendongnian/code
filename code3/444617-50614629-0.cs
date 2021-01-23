    Public class Pictures_Tag
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Picture")]
        public Int16 Picture_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("ImageTag")]
        public Int16 ImageTag_ID { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual ImageTag ImageTag { get; set; }
