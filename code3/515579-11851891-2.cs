    public class Gallery
    {
        // <SNIP>
    
        [ForeignKey("CoverPaintingId")]
        public virtual Painting Cover { get; set; }
        public int? CoverPaintingId { get; set; }
    
        public virtual Painting Slider { get; set; }
        [ForeignKey("Slider")]                     
        public int? SliderPaintingId {get;set;}
    
    }
