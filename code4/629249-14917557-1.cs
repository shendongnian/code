    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string PartId { get; set; }
        public DateTime Manufactured { get; set; }
        public string SerialNumber { get; set; }
        public string ProductType { get; set; }
        //Added this...
        public int? ParentComponentId { get; set; }
        [ForeignKey("ParentComponentId")]
        public virtual Component ParentComponent { get; set; }
        public virtual List<Component> SubComponents { get; set; }
        public string Description { get; set; }
    }
