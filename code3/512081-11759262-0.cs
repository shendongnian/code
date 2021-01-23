    public class Something {
            public int SomethingId { get; set; }
            [ForeignKey("Layer1")]
            public int Layer1Id { get; set; }
            [ForeignKey("Layer2")]
            public int Layer2Id { get; set; }
            [ForeignKey("Layer3")]
            public int Layer3Id { get; set; }
            [ForeignKey("Layer1Id")]
            public Layer Layer1 { get; set; }
            [ForeignKey("Layer2Id")]
            public Layer Layer2 { get; set; }
            [ForeignKey("Layer3Id")]
            public Layer Layer3 { get; set; }
        }
    
        public class Layer {
            public int LayerId { get; set; }
            [InverseProperty("Layer1")]
            public Something Something1 { get; set; }
            [InverseProperty("Layer2")]
            public Something Something2 { get; set; }
            [InverseProperty("Layer3")]
            public Something Something3 { get; set; }
        }
