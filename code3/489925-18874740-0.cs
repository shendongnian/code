            [Table(Name = "tVariant")]
            public class tVariantDouble
            {
                [Column(IsPrimaryKey = true, IsDbGenerated = true)]
                public int variantID { get; set; }
        
                [Column(CanBeNull = true)]
                public double? myVariant { get; set; }
        
                [Column(CanBeNull = true)]
                public string name { get; set; }
        
                [Column(CanBeNull = false)]
                public int typeID { get; set; }
    
                public tVariantDouble() { typeID = 1; }
        };
        [Table(Name = "tVariant")]
        public class tVariantInteger
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int variantID { get; set; }
    
            [Column(CanBeNull = true)]
            public int? myVariant { get; set; }
    
            [Column(CanBeNull = true)]
            public string name { get; set; }
    
            [Column(CanBeNull = false)]
            public int typeID { get; set; }
            public tVariantInteger() { typeID = 2; }
    };
