    public class Company
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        public int EmployeeAmount { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string CountryId {get; set; }
    }
