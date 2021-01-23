    public class Employee
    {
        Insurance Insurance { get; set; }
        public Employee()
        {
            this.Insurance = new Insurance() { PolicyId = -1 };
        }
    }
    public class Insurance
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
    }
