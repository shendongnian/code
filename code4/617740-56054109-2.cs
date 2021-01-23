        [Key]
        public int ParentId { get; set; }
        [ForeignKey(nameof(ParentId ))]
        public ParentTable Parent{ get; set; }
        public int Col1 { get; set; }
        public int Col2 { get; set; }
        public int ValueCol { get; set; }
