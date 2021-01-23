    class Primitive
    {
        public int PrimitiveId { get; set; }
        public double Data { get; set; }
        [Required]
        public Reference ReferenceClass { get; set; }
    }
    // This is the class that requires an array of doubles
    class Reference
    {
        // Other EF stuff
        // EF-acceptable reference to an 'array' of doubles
        public virtual List<Primitive> Data { get; set; }
    }
