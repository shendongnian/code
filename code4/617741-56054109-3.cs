        [Key, Column(Order = 0)]
        public int ParentId { get; set; }
        [ForeignKey(nameof(ParentId ))]
        public ParentTable Parent{ get; set; }
        [Key, Column(Order = 1)]
        public int Col1 { get; set; }
        [Key, Column(Order = 2)]
        public int Col2 { get; set; }
        public int ValueCol { get; set; }
