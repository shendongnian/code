    public class FilterCriterion {
        public bool HasEmployeeName { get { return !string.IsNullOrWhiteSpace(EmployeeName); } }
        public bool HasEmployeeNumber { get { return !string.IsNullOrWhiteSpace(EmployeeNumber); } }
        public bool HasDepartment { get { return !string.IsNullOrWhiteSpace(Department); } }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
    }
