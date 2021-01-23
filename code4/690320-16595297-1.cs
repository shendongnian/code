    public class CompanyViewModel
    {
        public int Id { get; set; }
        [StringLength(25, ErrorMessage="Company name needs to be 25 characters or less!")]
        public string Name { get; set; }
        public int EmployeeAmount { get; set; }
        public string CountryId { get; set; }
    }
