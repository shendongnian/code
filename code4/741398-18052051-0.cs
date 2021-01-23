     public class TextBoxGrid
        {
            public string EnteredValue { get; set; }
            public List<EmployeeDetails> employees;
        }
        public class ParentViewModel
        {
            public EmployeeDetails EmployeeDetails { get; set; }
            public TextBoxGrid TextBoxGrid { get; set; }
        }
        public class EmployeeDetails
        {
            public string EnteredValue { get; set; }
            public string EmployeeId { get; set; }
            public string ManagerId { get; set; }
        }
