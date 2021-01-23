    public class Building
    {
        [Key]
        public virtual  Guid Id { get; set; }
        public virtual List<Person> WorksHere { get; set; }
    
        public virtual Person MaintainedBy { get; set; }
        public virtual String Address { get; set; }
    }
