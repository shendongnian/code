    public class Employee
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int? AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
    
        public virtual IEnumerable<WorkRecord> WorkRecords { get; set; }
    }
