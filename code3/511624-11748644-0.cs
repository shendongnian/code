    public class Form
    {
        [Key]
        public int ID { get; set;}
    
        public Part Part { get; set;}      // Reference to Part
        public int? PartId { get; set; }   // Foreign Key to Part ID
    }
    
    public class Car : Vehicle
    {
        [Key]
        public int ID { get; set;}
    
        public virtual ICollection<Part> Parts { get; set;} //Each car has parts
    }
    
    public class Part
    {
        [Key]
        public int ID { get; set;}
    
        public Car Car { get; set;}      // Reference to Car
        public int? CarId { get; set; }   // Foreign Key to Car
    }
