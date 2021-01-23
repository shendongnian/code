    public class EnterValuesViewModel
    {
        public string EnteredValue { get; set; }
        public List<EmployeeDetailsViewModel> Employees { get; set; }
    }
    public class EmployeeDetailsViewModel
    {
        public string EmployeeId { get; set; }
        public string ManagerId { get; set; }
    }
