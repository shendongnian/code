    public class Employee
    {
        Insurance InsurancePolicy { get; set; }
        public Employee()
        {
            this.InsurancePolicy = new Insurance() { PolicyId = -1 };
        }
        public class Insurance
        {
            public int PolicyId { get; set; }
            public string PolicyName { get; set; }
        }
    }
