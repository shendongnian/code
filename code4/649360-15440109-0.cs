    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        
        [ForeignKey("Company"), Required]
        public int CompanyID { get; set; }
     
        public virtual Company Company { get; set; }
    }
